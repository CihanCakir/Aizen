using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationPackageFeatureEntity :AizenEntityWithAudit
    {
           public string Name { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }

                public long ApplicationId { get; set; }
    public ApplicationEntity? Application { get; set; }

    }
}