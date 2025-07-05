using System.Data.Entity;
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
using Microsoft.EntityFrameworkCore.Query;

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
    var appId = _infoAccessor.ClientInfoAccessor.ClientInfo.ApplicationId;
    var applicationCache = await _cache.GetAsync<RedisGeneralResponse<ApplicationCacheRuleItem>>($"{cacheKey}:{appId}", cancellationToken);

    if (applicationCache == null)
        throw new AizenBusinessException((int)AizenErrorCode.ApplicationNotFound) { IsRollback = false };

    var app = applicationCache.Value.Application;

    #region [AGE & ADULT CONTROL]
    if (app.AgeLimit.HasValue && request.BirthDate.HasValue)
    {
        int age = CalculateAge(request.BirthDate.Value);
        
        if (age > app.AgeLimit)
            throw new AizenBusinessException((int)AizenErrorCode.AgeLimitExceeded) { IsRollback = false };

        if (app.IsForAdult && age < 18)
            throw new AizenBusinessException((int)AizenErrorCode.AdultContentRestricted) { IsRollback = false };
    }
    #endregion

    #region [COUNTRY CONTROL]
    var selectedCountry = applicationCache.Value.ValidCountries.Content.Countries
        .FirstOrDefault(x => x.Code == request.CountryCode);

    if (selectedCountry == null)
        throw new AizenBusinessException((int)AizenErrorCode.CountryNotAllowed) { IsRollback = false };
    #endregion

    #region [DUPLICATE PHONE CONTROL]
    var usersWithSamePhone = await _unitOfWork.GetRepository<AizenUserEntity>()
        .GetAllAsync(
            predicate: x => x.PhoneNumber == request.PhoneNumber,
            include: z => (IIncludableQueryable<AizenUserEntity, object>)z.Include(y => y.ApplicationProfiles)
        );

    if (usersWithSamePhone.Any(x => x.ApplicationProfiles!.Select(z=> z.ApplicationId).ToList().Contains(appId)))
        throw new AizenBusinessException((int)AizenErrorCode.PhoneAlreadyRegistered) { IsRollback = false };

    #endregion

    // Buraya kullanıcı oluşturma, kayıt token üretme, sms gönderme, oturum başlatma gibi işlemler eklenecek.




            throw new NotImplementedException();
        }
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}