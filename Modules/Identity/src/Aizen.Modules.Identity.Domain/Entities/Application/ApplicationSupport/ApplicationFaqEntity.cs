using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Data.Mongo.Document;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationFaqEntity : AizenDefinitionDocumentBase
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? RedirectUrl { get; set; }


        public long? ApplicationId { get; set; }
    }
}