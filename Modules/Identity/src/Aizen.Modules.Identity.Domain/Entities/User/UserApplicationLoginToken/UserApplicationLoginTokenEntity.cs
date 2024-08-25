using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationLoginTokenEntity : AizenEntityWithAudit
{
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }


        public long DeviceId { get; set; }
        public UserApplicationDeviceEntity? Device { get; set; }

        public long ApplicationId { get; set; }
        public ApplicationEntity? Application { get; set; }

        public long UserId { get; set; }
        public AizenUserEntity? User { get; set; }

}