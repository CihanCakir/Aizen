using Aizen.Core.Data.Mongo.Document;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class UserApplicationSupportEntity : AizenDefinitionDocumentBase
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? SupportTopic { get; set; }
        public bool IsSolved { get; set; }

        public ApplicationSupportEntity? SupportType { get; set; }

        public UserApplicationSupportEntity? Answer { get; set; }


        public long ApplicationId { get; set; }
        public ApplicationEntity? Application { get; set; }

        public long UserId { get; set; }
        public AizenUserEntity? User { get; set; }

    }
}