using Aizen.Core.Domain;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class UserApplicationPackageFeatureUsedEntity : AizenEntityWithAudit
    {
        public long PurchasedFeatureId { get; set; } // Kullanıcı tarafından satın alınan özellik kimliği
        public UserApplicationPackageFeatureEntity? UserPurchasedFeature { get; set; } // İlgili UserPurchasedFeature tablosuyla ilişki

        public long? PurchasedFeatureBundleId { get; set; } // Eğer kullanım bir bundle içinden yapıldıysa, bu ID
        public UserApplicationPackageFeatureBundleEntity UserPurchasedFeatureBundle { get; set; } // İlgili UserPurchasedFeatureBundle tablosuyla ilişki

        public DateTime UsageDate { get; set; } // Özelliğin kullanıldığı tarih
        public string Location { get; set; } // Özelliğin kullanıldığı yerin bilgisi (şehir, ülke vb.)
        public string UsedFor { get; set; } // Özelliğin ne amaçla kullanıldığına dair açıklama (örn. "Hızlı Kaydırma", "Mesajlaşma")

        public ApplicationPlatform Platform { get; set; }
    }
}