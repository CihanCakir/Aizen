using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.DataStore.Domain.User
{
    public class UserEntity : AizenEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<UserCardMapEntity> MappingCards { get; set; }
    }
}