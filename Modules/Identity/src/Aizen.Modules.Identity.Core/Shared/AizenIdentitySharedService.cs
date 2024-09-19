using Aizen.Core.Cache.Abstraction;
using Aizen.Core.InfoAccessor.Abstraction;
using Aizen.Core.UnitOfWork.Abstraction;
using Aizen.Modules.Identity.Abstraction.Dto.Authentication;
using Aizen.Modules.Identity.Domain.Entities;
using Aizen.Modules.Identity.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Aizen.Modules.Identity.Core.Shared
{
    public class AizenIdentitySharedService : IAizenIdentitySharedService
    {
        private readonly IAizenDistributedCache _cacheService;
        private readonly IAizenUnitOfWork<AizenIdentityDbContext> _unitOfWork;
        private readonly IAizenInfoAccessor _infoAccessor;

        public AizenIdentitySharedService(IAizenDistributedCache cacheService, IAizenUnitOfWork<AizenIdentityDbContext> unitOfWork, IAizenInfoAccessor infoAccessor)
        {
            _cacheService = cacheService;
            _unitOfWork = unitOfWork;
            _infoAccessor = infoAccessor;
        }


        public async Task<AizenLoginDto> CreateLoginToken(AizenLoginTokenDto request)
        {
            await this.CheckDeviceHasBeenAproval(request);

            throw new NotImplementedException();
        }

        public async Task CheckDeviceHasBeenAproval(AizenLoginTokenDto request)
        {

            var deviceCount = await _unitOfWork.GetRepository<UserApplicationDeviceBlockEntity>().FirstOrDefaultAsync(x =>
                x.DeviceId == request.DeviceId && x.CreateDate.Value.Date == DateTime.Now.Date && x.IsActive == true);

            if (deviceCount != null)
                throw new AizenBusinessException((int)AizenErrorCode.CurrentDeviceHasBeenLockup);

            var currentDeviceLogins = await (await _unitOfWork.GetRepository<UserApplicationLoginTokenEntity>().GetAllAsync(x =>
                    x.MobileDeviceId == request.DeviceId && x.CreateDate.Value.Date == DateTime.Now.Date))
                .GroupBy(account => new
                { account.MobileDeviceId, account.ProfileId })
                .Select(x => new DeviceGroupDto
                {
                    DeviceId = x.Key.MobileDeviceId,
                    Count = x.Count(),
                }).ToListAsync();

            if (currentDeviceLogins.Count >= 3)
            {
                await _unitOfWork.GetRepository<UserApplicationDeviceBlockEntity>().AddAsync(
                    UserApplicationDeviceBlockEntity.CreateEntity(
                        deviceName: _infoAccessor.DeviceInfoAccessor.DeviceInfo.Brand,
                        deviceId: request.DeviceId,
                        ipAddress: _infoAccessor.DeviceInfoAccessor.DeviceInfo.IpAddress,
                        deviceTypeId: int.Parse(_contextAccessor.HttpContext.Request.Headers["x-client-platform"])));
                await _unitOfWorkForUser.SaveChangesAsync();
                throw new AizenBusinessException((int)AizenErrorCode.CurrentDeviceHasBeenLockup)
                { IsRollback = false };
            }
        }


    }
}