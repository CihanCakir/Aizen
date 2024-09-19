using Aizen.Core.Domain;

namespace Aizen.Modules.DataStore.Domain.Wallet
{
    public class BenefitCategoryEntity : AizenEntityWithAudit
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<BenefitEntity> Benefits { get; set; }

    }
}