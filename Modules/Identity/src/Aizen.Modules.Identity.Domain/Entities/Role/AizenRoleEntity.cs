using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class AizenRoleEntity : IdentityRole<long>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public long RoleTypeId { get; set; }
        public virtual AizenRoleTypeEntity RoleType { get; set; }

        public virtual ICollection<AizenUserEntity> Users { get; set; }

        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public string ModifyHost { get; set; }
        public long? ModifyUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public long? CreateUserId { get; set; }
        public string CreateHost { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}