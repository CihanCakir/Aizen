using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationEntity : AizenEntityWithAudit
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }

        public bool IsForAdult { get; set; }
        public int? AgeLimit { get; set; }
        public long TenantId { get; set; }
        public virtual TenantEntity? Tenant { get; set; }

        public virtual ICollection<ApplicationRuleEntity>? Rules { get; set; }
        public virtual ICollection<ApplicationPackageEntity>? Packages { get; set; }
        public virtual ICollection<AizenRoleEntity>? Roles { get; set; }
    }
}