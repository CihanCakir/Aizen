using Microsoft.AspNetCore.Identity;


namespace Aizen.Modules.Identity.Domain.Entities;

public class AizenUserEntity : IdentityUser<long>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public long RoleId { get; set; }
    public virtual AizenRoleEntity Role { get; set; }

    public virtual ICollection<UserApplicationProfileEntity>? ApplicationProfiles { get; set; }


    public static AizenUserEntity Create(string name, string surname)
    {
        return new AizenUserEntity { Name = name, Surname = surname };
    }
}

