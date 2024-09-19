using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.CQRS.Message;

namespace Aizen.Modules.DataStore.Application.Benefit
{
    public class CancelEarnedBenefitCommand: AizenCommand<AizenCommandResult>
    {
        public CancelEarnedBenefitCommand(int walletId, int orderId, string cardNumber, int earnedBenefitId)
        {
            this.WalletId = walletId;
            this.OrderId = orderId;
            this.CardNumber = cardNumber;
            this.EarnedBenefitId = earnedBenefitId;
        }

        public int WalletId { get; set; }
        public string CardNumber { get; set; }
        public int OrderId { get; set; }
        public int EarnedBenefitId { get; set; }

    }
}