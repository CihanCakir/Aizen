using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Modules.Identity.Domain.Entities;

namespace Aizen.Modules.Identity.Core.Cache
{
    public class ApplicationCacheRuleItem
    {
        public ApplicationEntity Application { get; set; }
        public ApplicationValidCountryEntity ValidCountries { get; set; }
    }
}