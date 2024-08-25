using Microsoft.AspNetCore.Identity;


namespace Aizen.Modules.Identity.Domain.Entities;

public class AizenUserEntity : IdentityUser<long>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }


    public virtual ICollection<UserApplicationStatuEntity>? ApplicationStatus { get; set; }
    public virtual ICollection<UserApplicationDeviceEntity>? ApplicationDevices { get; set; }
    public virtual ICollection<UserApplicationMessagePermissionEntity>? ApplicationMessagePermissions { get; set; }
    public virtual ICollection<UserApplicationLoginTokenEntity>? ApplicationLoginTokens { get; set; }
    public virtual ICollection<UserApplicationPasswordHistoryEntity>? ApplicationPasswordHistories { get; set; }
    public virtual ICollection<UserApplicationBlockEntity>? ApplicationBlocks { get; set; }
    public virtual ICollection<UserApplicationReportEntity>? ApplicationReports { get; set; }
    public virtual ICollection<UserApplicationEmailConfirmEntity>? ApplicationEmailConfirms { get; set; }

}

