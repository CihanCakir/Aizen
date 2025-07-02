using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationReportEntity : AizenEntityWithAudit
{
    public string? Description { get; set; }
    public DateTime ReportDate { get; set; }

    public long ReportedByUserId { get; set; }
    public virtual UserApplicationProfileEntity? ReportedByUser { get; set; }

    public long ReportedUserId { get; set; }
    public  virtual UserApplicationProfileEntity? ReportedUser { get; set; }



    public long RuleId { get; set; }
    public virtual ApplicationRuleEntity? Rule { get; set; }

    public long ApplicationId { get; set; }
    public virtual ApplicationEntity? Application { get; set; }
}