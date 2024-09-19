

using Aizen.Core.Messagebus.Abstraction.Messages;

namespace Aizen.Modules.DataStore.Abstraction.Messages
{
    public class CancelEarnedBenefitMessage : AizenBaseMessage
    {
        public int WalletId { get; set; }
        public string CardNumber { get; set; }
        public int OrderId { get; set; }
        public int EarnedBenefitId { get; set; }
    }

    public class CancelEarnedBenefitMessageResult : AizenMessageResult
    {
    }
}