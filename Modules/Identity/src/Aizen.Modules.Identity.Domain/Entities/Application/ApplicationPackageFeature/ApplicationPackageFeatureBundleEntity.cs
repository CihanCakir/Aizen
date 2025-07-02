using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities;
public class ApplicationPackageFeatureBundleEntity : AizenEntityWithAudit
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string? ResourceName { get; set; }
    public string? ResourceDescription { get; set; }

    public int Quantity { get; set; }

    public long? FeatureId { get; set; }
    public virtual ApplicationPackageFeatureEntity? Feature { get; set; }



    public long ApplicationId { get; set; }
    public virtual ApplicationEntity? Application { get; set; }


    public virtual ICollection<ApplicationCountryPriceEntity>? ApplicationCountryPrices { get; set; }


}