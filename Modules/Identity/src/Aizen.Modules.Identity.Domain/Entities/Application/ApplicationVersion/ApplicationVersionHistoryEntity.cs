using Aizen.Core.Data.Mongo.Document;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class ApplicationVersionHistoryEntity : AizenDefinitionDocumentBase
    {
        public ApplicationVersionEntity ApplicationVersion { get; set; }
        public ApplicationPlatformVersionAction Action { get; set; } // Enum: Güncellendi, Yayımlandı, Geri Çekildi
        public DateTime ActionDate { get; set; }
        public string PerformedBy { get; set; }
    }
}