using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationValidCountryEntity : AizenEntityWithAudit
    {
        public long ApplicationId { get; set; }
        public ApplicationEntity Application { get; set; }

        public ApplicationCountry Content { get; set; } //JObject 
    }
    public class ApplicationCountry
    {
        public List<CountryData> Countries { get; set; }
    }

    public class CountryData
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? PhoneCode { get; set; }
        public string? CurrencyIsoCode { get; set; }
        public string? CurrencyCode { get; set; }
    }
}