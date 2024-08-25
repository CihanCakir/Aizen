using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationDeviceEntity : AizenEntityWithAudit
{
    public string? NotificationToken { get; set; }
    public string? DeviceId { get; set; }
    public bool DeviceStatus { get; set; }

    public int? ConsumerDeviceTypeId { get; set; }
    public DateTime? LastLoginDate { get; set; }

    public long ApplicationId { get; set; }
    public ApplicationEntity? Application { get; set; }

    public long UserId { get; set; }
    public AizenUserEntity? User { get; set; }


    public virtual ICollection<UserApplicationLoginTokenEntity>? LoginTokens { get; set; }
}