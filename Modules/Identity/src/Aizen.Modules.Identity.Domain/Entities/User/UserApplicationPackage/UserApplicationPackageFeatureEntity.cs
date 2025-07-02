using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class UserApplicationPackageFeatureEntity : AizenEntityWithAudit
    {
    public long ProfileId { get; set; }
    public virtual UserApplicationProfileEntity? Profile { get; set; }
        public long FeatureId { get; set; }
        public virtual ApplicationPackageFeatureEntity? Feature { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}