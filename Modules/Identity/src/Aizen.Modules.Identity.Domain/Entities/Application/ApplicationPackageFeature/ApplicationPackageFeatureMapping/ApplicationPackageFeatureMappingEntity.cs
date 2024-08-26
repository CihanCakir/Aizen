using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationFeatureMappingEntity : AizenEntityWithAudit
    {
        public long PackageId { get; set; }
        public ApplicationPackageEntity Package { get; set; }

        public long FeatureId { get; set; }
        public ApplicationPackageFeatureEntity PackageFeature { get; set; }
    }
}