using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationPackageEntity : AizenEntityWithAudit
    {
        public string Name { get; set; }
        public string ResourceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public bool IsActive { get; set; }



        public long ApplicationId { get; set; }
        public ApplicationEntity? Application { get; set; }
    }
}