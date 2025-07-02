using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class UserApplicationReferenceEntity : AizenEntityWithAudit
    {
        public string? ReferenceCode { get; set; }
        public string? ReferenceLink { get; set; }
        public string? ReferenceDeepLink { get; set; }

        public long? TargetProfileId { get; set; }
        public virtual UserApplicationProfileEntity? TargetProfile { get; set; }

        public long OwnerProfileId { get; set; }
        public virtual UserApplicationProfileEntity OwnerProfile { get; set; }

        public long ApplicationId { get; set; }
        public virtual ApplicationEntity Application { get; set; }
    }
}