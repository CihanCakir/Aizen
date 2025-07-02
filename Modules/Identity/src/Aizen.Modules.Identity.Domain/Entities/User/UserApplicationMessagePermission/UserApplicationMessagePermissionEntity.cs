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
    public virtual ApplicationEntity? Application { get; set; }

    public long ProfileId { get; set; }
    public virtual UserApplicationProfileEntity? Profile { get; set; }
}