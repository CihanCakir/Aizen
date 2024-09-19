using Aizen.Core.Common.Abstraction.Exception;
using Aizen.Core.Domain;
using Aizen.Core.Infrastructure.Exception;

namespace Aizen.Modules.DataStore.Domain.Wallet;

public class WalletEntity : AizenEntityWithAudit
{
    public int CustomerId { get; protected set; }
    public int CustomerPersonelId { get; set; }
    public string CustomerName { get; protected set; }
    public string CardNo { get; protected set; }
    public decimal Balance { get; protected set; }
    public virtual ICollection<WalletTransactionEntity> Transactions { get; protected set; }
    public virtual ICollection<WalletOrderEntity> Orders { get; protected set; }

    public static WalletEntity Create(int customerId, string customerName, string cardNo, int customerPersonelId)
    {
        if (cardNo.Length == 16) cardNo += "00";
        return new WalletEntity
        {
            CustomerId = customerId,
            CustomerName = customerName,
            CardNo = cardNo,
            CustomerPersonelId = customerPersonelId
        };
    }

    public void CancelEarnedBenefit(int orderId, int earnedBenefitId, bool isComeFromCancel = false)
    {
        var order = Orders.FirstOrDefault(x => x.Id == orderId);
        if (order == null)
        {
            throw new AizenBusinessException("Order not found");
        }

        if (!isComeFromCancel && order.LastUsageDate < DateTime.Now)
        {
            throw new AizenBusinessException("Order has already delay to last usage date");
        }

        var selectedEarnedBenefit = order.EarnedBenefits.FirstOrDefault(x => x.Id == earnedBenefitId);
        if (selectedEarnedBenefit == null)
        {
            throw new AizenBusinessException("Earned benefit not found");
        }

        Balance += selectedEarnedBenefit.Amount;
        order.RemainingAmount += selectedEarnedBenefit.Amount;

        if ((order.Status == Status.Active || order.Status == Status.Used) && order.RemainingAmount == 0) order.Status = Status.Used;

        if (order.Status == Status.Used && order.RemainingAmount > 0) order.Status = Status.Active;

        var newTransaction = new WalletTransactionEntity
        {
            Wallet = this,
            Order = order,
            EarnedBenefit = selectedEarnedBenefit,
            Amount = selectedEarnedBenefit.Amount,
            Type = TransactionType.Restore,
        };
        order.EarnedBenefits.Remove(selectedEarnedBenefit);
        selectedEarnedBenefit.IsDeleted = true;
        selectedEarnedBenefit.Status = Status.Cancelled;
        order.EarnedBenefits.Add(selectedEarnedBenefit);
        Transactions.Add(newTransaction);
    }
}

public class WalletOrderEntity : AizenEntityWithAudit
{
    public int WalletId { get; set; }
    public virtual WalletEntity Wallet { get; set; }
    public int OrderHeaderId { get; set; }
    public int OrderDetailId { get; set; }
    public decimal Amount { get; set; }
    public decimal RemainingAmount { get; set; }
    public string Description { get; set; }
    public int OrderCount { get; set; }
    public Status Status { get; set; } = Status.Active;

    public DateTime LastUsageDate { get; set; }
    public virtual ICollection<WalletOrderBenefitEntity> Benefits { get; set; }
    public virtual ICollection<WalletTransactionEntity> Transactions { get; set; }
    public virtual ICollection<EarnedBenefitEntity> EarnedBenefits { get; set; }

    public void ActivateOrders()
    {
        Status = Status.Active;
    }

    public List<int> PossibleBenefitCategoriesIds()
    {
        List<int> listOfItems = new();
        if (this.Benefits != null)
        {
            listOfItems = this.Benefits.Select(x => x.Benefit.CategoryId).ToList();
        }

        return listOfItems;
    }
}

public enum Status
{
    Pending,
    Active,
    Used,
    Error,
    Cancelled
}

public class BenefitEntity : AizenEntityWithAudit
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public int PartnerId { get; set; } //SEFERDEN_GELEN_LISTE_ID
    public string Title { get; set; }
    public string Detail { get; set; }
    public string Img { get; set; }

    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }

    public virtual ICollection<WalletOrderBenefitEntity> WalletOrderBenefits { get; set; }
    public virtual ICollection<BenefitOptionEntity> Options { get; set; }

    public int CategoryId { get; set; }
    public virtual BenefitCategoryEntity Category { get; set; }
}

public class BenefitOptionEntity : AizenEntityWithAudit
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Code { get; set; }
    public decimal Value { get; set; }

    public int BenefitId { get; set; }
    public virtual BenefitEntity Benefit { get; set; }
}
public class WalletOrderBenefitEntity : AizenEntityWithAudit
{
    public int OrderId { get; set; }

    public virtual WalletOrderEntity Order { get; set; }

    public int BenefitId { get; set; }

    public virtual BenefitEntity Benefit { get; set; }

    public virtual ICollection<EarnedBenefitEntity>? EarnedBenefits { get; set; }

    public bool IsDefault { get; set; }
}

public enum TransactionType
{
    Deposit,
    Withdrawal,
    Cancel,
    Restore
}

public static class BenefitCustomType
{
    public const string DigitalCode = "Dijital Kod";
    public const string Card = "Kart";
    public const string Wallet = "Cüzdan";
}