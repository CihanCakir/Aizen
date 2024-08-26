using Aizen.Core.Domain;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationTaxesAndCommissionEntity : AizenEntityWithAudit
    {
        public string CountryCode { get; set; }
        public decimal VATRate { get; set; }
        public decimal PlatformCommissionRate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}