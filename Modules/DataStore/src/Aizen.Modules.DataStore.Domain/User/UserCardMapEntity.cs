using Aizen.Core.Domain;

namespace Aizen.Modules.DataStore.Domain.User
{
    public class UserCardMapEntity : AizenEntity
    {
        public int CustomerPersonnelId { get; set; }
        public bool IsOwner { get; set; }
        public bool Status { get; set; }

        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}