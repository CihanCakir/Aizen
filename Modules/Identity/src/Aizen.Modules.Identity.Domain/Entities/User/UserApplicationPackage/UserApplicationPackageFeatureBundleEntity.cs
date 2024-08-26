using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class UserApplicationPackageFeatureBundleEntity: AizenEntityWithAudit
    {
    public long ProfileId { get; set; }
    public UserApplicationProfileEntity? Profile { get; set; }
        public long FeatureBundleId { get; set; }
        public ApplicationPackageFeatureBundleEntity? FeatureBundle { get; set; }

        public DateTime PurchaseDate { get; set; }
        public bool IsActive { get; set; }
        public int RemainingQuantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}