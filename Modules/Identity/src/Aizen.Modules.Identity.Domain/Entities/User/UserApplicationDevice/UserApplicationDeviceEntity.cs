using Aizen.Core.Domain;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationDeviceEntity : AizenEntityWithAudit
{
    public ApplicationPlatform Platform { get; set; }
    public string? NotificationToken { get; set; }
    public string? DeviceId { get; set; }
    public bool DeviceStatus { get; set; }

    public int? ConsumerDeviceTypeId { get; set; }
    public DateTime? LastLoginDate { get; set; }

    public long ApplicationId { get; set; }
    public virtual ApplicationEntity? Application { get; set; }

    public long ProfileId { get; set; }
    public virtual  UserApplicationProfileEntity? Profile { get; set; }


    public virtual ICollection<UserApplicationLoginTokenEntity>? LoginTokens { get; set; }
}