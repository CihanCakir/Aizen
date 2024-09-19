using Aizen.Core.Domain;

namespace Aizen.Modules.DataStore.Domain.Wallet;

public class WalletTransactionEntity : AizenEntityWithAudit
{
    public int WalletId { get; set; }
    public virtual WalletEntity Wallet { get; set; }
    public int OrderId { get; set; }
    public virtual WalletOrderEntity Order { get; set; }

    public virtual int? EarnedBenefitId { get; set; }
    public virtual EarnedBenefitEntity? EarnedBenefit { get; set; }

    public decimal Amount { get; set; }
    public string Description { get; set; }
    public TransactionType Type { get; set; }

    public static WalletTransactionEntity Create(int walletId,
                                   int orderId,
                                   int? earnedBenefitId,
                                   decimal amount,
                                   string description,
                                   TransactionType type)
    {
        return new WalletTransactionEntity
        {
            WalletId = walletId,
            OrderId = orderId,
            EarnedBenefitId = earnedBenefitId,
            Amount = amount,
            Description = description,
            Type = type,
        };
    }
}