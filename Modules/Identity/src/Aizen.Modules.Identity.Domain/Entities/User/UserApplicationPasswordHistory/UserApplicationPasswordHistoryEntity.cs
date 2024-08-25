using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationPasswordHistoryEntity : AizenEntityWithAudit
{
     public string? PasswordHash { get; set; }
     public bool PasswordStatus { get; set; }

   
     public long ApplicationId { get; set; }
     public ApplicationEntity? Application { get; set; }

     public long UserId { get; set; }
     public AizenUserEntity? User { get; set; }
}