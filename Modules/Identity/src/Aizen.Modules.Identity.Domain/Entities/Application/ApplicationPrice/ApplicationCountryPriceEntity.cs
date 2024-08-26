using Aizen.Core.Domain;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationCountryPriceEntity : AizenEntityWithAudit
    {
        public ApplicationPlatform Platform { get; set; }

        public string CountryCode { get; set; }
        public decimal BasePrice { get; set; }
        public string Currency { get; set; }
        public decimal VATRate { get; set; }
        public decimal PlatformCommissionRate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }



        public long? PackageId { get; set; }
        public ApplicationPackageEntity? Package { get; set; }

        public long? FeatureId { get; set; }
        public ApplicationPackageFeatureBundleEntity? Feature { get; set; }

        public long? FeatureBundleId { get; set; }
        public ApplicationPackageFeatureBundleEntity? FeatureBundle { get; set; }

        public virtual ICollection<ApplicationPriceHistoryEntity>? PriceHistories { get; set; }
    }
}