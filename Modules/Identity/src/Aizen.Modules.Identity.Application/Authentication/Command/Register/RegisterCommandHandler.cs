using Aizen.Core.Api.Middleware;
using Aizen.Core.Auth.Abstraction;
using Aizen.Core.Cache.Abstraction;
using Aizen.Core.Cache.Abstraction.Common;
using Aizen.Core.CQRS.Handler;
using Aizen.Core.InfoAccessor.Abstraction;
using Aizen.Core.Infrastructure.Exception;
using Aizen.Core.UnitOfWork.Abstraction;
using Aizen.Modules.Identity.Abstraction.Dto.Authentication;
using Aizen.Modules.Identity.Core.Cache;
using Aizen.Modules.Identity.Domain.Entities;
using Aizen.Modules.Identity.Repository.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Aizen.Modules.Identity.Application.Authentication.Command
{
    public class RegisterCommandHandler : AizenCommandHandler<RegisterCommand, AizenLoginDto>
    {
        private readonly IAizenUnitOfWork<AizenIdentityDbContext> _unitOfWork;
        private readonly UserManager<AizenUserEntity> _userManager;
        private readonly IAizenInfoAccessor _infoAccessor;
        private readonly SignInManager<AizenUserEntity> _signInManager;
        private readonly IAizenTokenHelper _tokenHelper;
        private readonly IAizenDistributedCache _cache;
        private const string cacheKey = "Identity:Application:Rule";

        public RegisterCommandHandler(IAizenUnitOfWork<AizenIdentityDbContext> unitOfWork, UserManager<AizenUserEntity> userManager, IAizenInfoAccessor infoAccessor, SignInManager<AizenUserEntity> signInManager, IAizenTokenHelper aizenTokenHelper, IAizenDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _infoAccessor = infoAccessor;
            _signInManager = signInManager;
            _tokenHelper = aizenTokenHelper;
            _cache = cache;
        }
        public override async Task<AizenLoginDto?> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var applicationCache = await _cache.GetAsync<RedisGeneralResponse<ApplicationCacheRuleItem>>(string.Concat(cacheKey, ":", _infoAccessor.ClientInfoAccessor.ClientInfo.ApplicationId), cancellationToken);

            if (applicationCache == null) return null; // CHECK APPLICATION FROM CACHE

            // AGE & ADULT CONTROL
            if (applicationCache.Value.Application.AgeLimit.HasValue)
            {
                int age = DateTime.Now.Year - request.BirthDate.Value.Year;

                if (DateTime.Now.Month < request.BirthDate.Value.Month || (DateTime.Now.Month == request.BirthDate.Value.Month && DateTime.Now.Day < request.BirthDate.Value.Day))
                {
                    age--;
                }
                if (age > applicationCache.Value.Application.AgeLimit) throw new AizenBusinessException((int)AizenErrorCode.CurrentDeviceHasBeenLockup) // AGE_LIMIT
                { IsRollback = false };
                if (applicationCache.Value.Application.IsForAdult && age < 18) throw new AizenBusinessException((int)AizenErrorCode.CurrentDeviceHasBeenLockup) // ADULT_CONTROL
                { IsRollback = false };
            }

            // COUNTRY CONTROL
            var selectedCountry = applicationCache.Value.ValidCountries.Content.Countries.FirstOrDefault(country => country.Code == request.CountryCode);

            if (selectedCountry == null) throw new AizenBusinessException((int)AizenErrorCode.CurrentDeviceHasBeenLockup) { IsRollback = false }; // COUNTRY_CONTROL

            #region [SEND_QUE_CONTROL]
            // PHONE_REGISTER_OTHER_APPLICATON_CONTROL
            var checkUser = await _unitOfWork.GetRepository<AizenUserEntity>().GetAllAsync(predicate: x => x.PhoneNumber == request.PhoneNumber);

            if (checkUser.Any())
            {

            }
            #endregion

            // var user = AizenUserEntity.



            throw new NotImplementedException();
        }
    }

}