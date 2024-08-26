using Microsoft.AspNetCore.Identity;


namespace Aizen.Modules.Identity.Domain.Entities;

public class AizenUserEntity : IdentityUser<long>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }


    public virtual ICollection<UserApplicationProfileEntity>? ApplicationProfiles { get; set; }

}

