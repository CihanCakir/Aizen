namespace Aizen.Core.InfoAccessor.Abstraction;

public interface IAizenUserInfoAccessor
{
    public AizenUserInfo UserInfo { get; }
}

public class AizenUserInfo : IAizenInfo
{
    public InfoLifeCycle LifeCycle => InfoLifeCycle.Scoped;
    public long UserId { get; set; }
    public long CompanyId { get; set; }
    public long TenantId { get; set; }
    public long RoleId { get; set; }
    public string PhoneNumber { get; set; }

}