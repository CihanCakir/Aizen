using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Data.Mongo.Document;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationVersionEntity : AizenDefinitionDocumentBase
    {
        public string VersionNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ApplicationPlatform Platform { get; set; } 
        public string Description { get; set; }
        public bool IsMandatory { get; set; }
    }
}