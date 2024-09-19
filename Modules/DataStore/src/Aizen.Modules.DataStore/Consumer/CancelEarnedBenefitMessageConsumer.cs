using Aizen.Core.CQRS.Abstraction;
using Aizen.Core.Messagebus.Abstraction.Consumers;
using Aizen.Core.Messagebus.Abstraction.Messages;
using Aizen.Modules.DataStore.Abstraction.Messages;
using Aizen.Modules.DataStore.Application.Benefit;

namespace Aizen.Modules.DataStore.Consumers
{
    public class CancelEarnedBenefitMessageConsumer : AizenBaseMessageConsumer<CancelEarnedBenefitMessage, CancelEarnedBenefitMessageResult>
    {
        private readonly IAizenCQRSProcessor _cqrsProcessor;

        public CancelEarnedBenefitMessageConsumer(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _cqrsProcessor = serviceProvider.GetRequiredService<IAizenCQRSProcessor>();
        }

        public override Task<bool> ExecutePrepareMessage(CancelEarnedBenefitMessage message,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public override async Task<CancelEarnedBenefitMessageResult> ExecuteCommitMessage(
            CancelEarnedBenefitMessage message, CancellationToken cancellationToken)
        {
            await _cqrsProcessor.ProcessAsync(new CancelEarnedBenefitCommand(
                                                                            walletId: message.WalletId,
                                                                            orderId: message.OrderId,
                                                                            cardNumber: message.CardNumber,
                                                                            earnedBenefitId: message.EarnedBenefitId
                                                                           ), cancellationToken);

            return new CancelEarnedBenefitMessageResult();
        }

        public override Task ExecuteRollbackMessage(CancelEarnedBenefitMessage message, AizenMessageError ex,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
