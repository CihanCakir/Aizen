using Aizen.Core.Domain;
using Aizen.Modules.Identity.Abstraction.Enum;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationStatuEntity : AizenEntityWithAudit
{
    public ApplicationAccountLoginType LoginType { get; set; }
    public ApplicationAccountStatu AccountStatu { get; set; }
    public ApplicationAccountType AccountType { get; set; }
   
   
    public long ApplicationId { get; set; }
    public ApplicationEntity? Application { get; set; }

    public long ProfileId { get; set; }
    public UserApplicationProfileEntity? Profile { get; set; }
}