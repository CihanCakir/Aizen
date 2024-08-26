using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationPriceHistoryEntity : AizenEntityWithAudit
    {
        public long CountryPricingId { get; set; }
        public ApplicationCountryPriceEntity CountryPricing { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
    }
}