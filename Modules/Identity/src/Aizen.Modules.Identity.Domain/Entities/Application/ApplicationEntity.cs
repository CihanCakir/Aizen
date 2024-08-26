using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationEntity : AizenEntityWithAudit
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }

        public bool IsForAdult { get; set; }
        public long TenantId { get; set; }
        public TenantEntity? Tenant { get; set; }

        public virtual ICollection<ApplicationRuleEntity>? Rules { get; set; }
        public virtual ICollection<ApplicationPackageEntity>? Packages { get; set; }
    }
}