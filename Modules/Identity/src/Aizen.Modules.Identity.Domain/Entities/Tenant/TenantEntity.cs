using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class TenantEntity : AizenEntityWithAudit
    {
        public string? Name { get; set; }
        public string? Description { get; set; }


        public virtual ICollection<ApplicationEntity>? Applications { get; set; }
    }
}