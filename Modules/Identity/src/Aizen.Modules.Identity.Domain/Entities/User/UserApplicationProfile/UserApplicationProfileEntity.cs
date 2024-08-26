using Aizen.Core.Domain;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities;


public class UserApplicationProfileEntity : AizenEntityWithAudit
{
    public string Gender { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; } 
    public DateTime LastActiveDate { get; set; }
    public ApplicationAccountStatu AccountStatu { get; set; }
    public ApplicationAccountVerificationStatu VerificationStatu { get; set; }

    public  long ApplicationStatuId { get; set; }
    public  UserApplicationStatuEntity? ApplicationStatus { get; set; }
    public long ApplicationId { get; set; }
    public ApplicationEntity? Application { get; set; }

    public long UserId { get; set; }
    public AizenUserEntity? User { get; set; }


    public virtual ICollection<UserApplicationDeviceEntity>? ApplicationDevices { get; set; }
    public virtual ICollection<UserApplicationMessagePermissionEntity>? ApplicationMessagePermissions { get; set; }
    public virtual ICollection<UserApplicationLoginTokenEntity>? ApplicationLoginTokens { get; set; }
    public virtual ICollection<UserApplicationPasswordHistoryEntity>? ApplicationPasswordHistories { get; set; }
    public virtual ICollection<UserApplicationBlockEntity>? ApplicationBlocks { get; set; }
    public virtual ICollection<UserApplicationReportEntity>? ApplicationReports { get; set; }
    public virtual ICollection<UserApplicationEmailConfirmEntity>? ApplicationEmailConfirms { get; set; }
}