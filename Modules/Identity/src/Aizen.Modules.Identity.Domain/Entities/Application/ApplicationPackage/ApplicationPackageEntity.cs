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

        public virtual ICollection<ApplicationCountryPriceEntity>? CountryPrices { get; set; }
        public virtual ICollection<ApplicationFeatureMappingEntity>? PackageFeatures { get; set; }

        public long ApplicationId { get; set; }
        public virtual ApplicationEntity? Application { get; set; }
    }
}