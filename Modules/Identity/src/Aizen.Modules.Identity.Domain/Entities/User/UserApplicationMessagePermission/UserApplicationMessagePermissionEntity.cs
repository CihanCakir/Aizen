using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationMessagePermissionEntity : AizenEntityWithAudit
{
    public int PermissionTypeId { get; set; }
    public int? PermissionContentId { get; set; }
    public bool? PermissionValue { get; set; }
    public bool Status { get; set; }
    public bool IYSStatus { get; set; }


    public long ApplicationId { get; set; }
    public ApplicationEntity? Application { get; set; }

    public long UserId { get; set; }
    public AizenUserEntity? User { get; set; }
}