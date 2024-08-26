using Aizen.Core.Domain;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationBlockEntity : AizenEntityWithAudit
{
    public ApplicationRuleBlockType BlockedBy { get; set; } // Enum: Sistem, Kullanıcı
    public string? IpAddress { get; set; }
    public string? BlockReason { get; set; }
    public DateTime? BlockedUntil { get; set; }
    public bool IsActive { get; set; }



    public long ProfileId { get; set; }
    public UserApplicationProfileEntity? Profile { get; set; }

    public long ApplicationId { get; set; }
    public ApplicationEntity? Application { get; set; }

    public long RuleId { get; set; }
    public ApplicationRuleEntity? Rule { get; set; }
}