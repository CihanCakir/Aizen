using Aizen.Core.Domain;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities;
public class ApplicationRuleEntity : AizenEntityWithAudit
{   
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ApplicationRuleType Type { get; set; } 
    public ApplicationRuleSecurityLevel SeverityLevel { get; set; } 



    public long ApplicationId { get; set; }
    public virtual ApplicationEntity? Application { get; set; }
}