using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Data.Mongo.Document;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class UserApplicationValidationEntity : AizenDefinitionDocumentBase
    {
        public int UserValidationTypeId { get; set; }
        public ApplicationPlatformType ValidationType { get; set; }
        public string ValidationReferance { get; set; }
        public string? RelationCode { get; set; }
        public int ValdationCode { get; set; }
        public int State { get; set; }
        public int ApplicationId { get; set; }
        public string ValidationGuid { get; set; }
    }
}