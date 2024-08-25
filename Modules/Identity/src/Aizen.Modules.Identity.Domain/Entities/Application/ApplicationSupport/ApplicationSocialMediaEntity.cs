using Aizen.Core.Data.Mongo.Document;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationSocialMediaEntity : AizenDefinitionDocumentBase
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }

                public long? ApplicationId { get; set; }

    }
}