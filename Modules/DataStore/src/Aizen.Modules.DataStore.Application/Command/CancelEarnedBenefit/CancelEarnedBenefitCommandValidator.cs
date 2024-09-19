using FluentValidation;
using Aizen.Core.Validation;

namespace Aizen.Modules.DataStore.Application.Benefit
{
    public class CancelEarnedBenefitCommandValidator: AizenValidator<CancelEarnedBenefitCommand>
    {
        public CancelEarnedBenefitCommandValidator()
        {
            RuleFor(x => x.CardNumber)
                .NotNull()
                .NotEmpty()
            .WithMessage("CardNumber not null or empty");

            RuleFor(x => x.WalletId)
                .NotNull()
                .NotEmpty()
            .WithMessage("WalletId not null or empty");

            RuleFor(x => x.OrderId)
                .NotNull()
                .NotEmpty()
            .WithMessage("OrderId not null or empty");

            RuleFor(x => x.EarnedBenefitId)
                .NotNull()
                .NotEmpty()
            .WithMessage("EarnedBenefitId not null or empty");                                    
        }
    }
}