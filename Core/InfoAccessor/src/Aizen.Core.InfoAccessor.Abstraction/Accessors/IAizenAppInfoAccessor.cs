namespace Aizen.Core.InfoAccessor.Abstraction;

public interface IAizenAppInfoAccessor
{
    public AizenAppInfo AppInfo { get; }
}

public enum AppType
{
    Api,
    Gateway,
    Bff,
    Worker,
    Scheduler
}

public class AizenAppInfo : IAizenInfo
{
    public InfoLifeCycle LifeCycle => InfoLifeCycle.Singleton;

    public AppType Type { get; set; } 
    public string Name { get; set; } 
    public bool IdentityInclude { get; set; } 
    public string GroupName { get; set; }
    public string GroupColor { get; set; }
    public string GroupIcon { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string ModuleColor { get; set; }
    
    
}