using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class AizenRoleTypeEntity : AizenEntityWithAudit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Level { get; set; }
        public virtual ICollection<AizenRoleEntity> Roles { get; set; } = new List<AizenRoleEntity>();
    }
}