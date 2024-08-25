using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class UserApplicationEmailConfirmEntity : AizenEntityWithAudit
    {
        public string? Email { get; set; }
        public bool IsConfirm { get; set; }
        public string? ValidationGuid { get; set; }
        public string? ValidationString { get; set; }
        public DateTime ExpiredDateTime { get; set; }



    public long ApplicationId { get; set; }
    public ApplicationEntity? Application { get; set; }

    public long UserId { get; set; }
    public AizenUserEntity? User { get; set; }
        }
}