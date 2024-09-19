using Aizen.Core.Domain;

namespace Aizen.Modules.DataStore.Domain.Wallet;
public class GroupEarnedBenefit
{
    public int CustomerId { get; set; }
    public int PartnerId { get; set; }
    public string Type { get; set; }
    public int OrderCount { get; set; }
    public List<EarnedBenefitEntity> Benefits { get; set; }

}
public class EarnedBenefitEntity : AizenEntityWithAudit
{
    public int OrderId { get; set; }
    public virtual WalletOrderEntity Order { get; set; }

    public int TransactionId { get; set; }
    public virtual WalletTransactionEntity Transaction { get; set; }

    public int BenefitId { get; set; }
    public virtual WalletOrderBenefitEntity Benefit { get; set; }

    public Status Status { get; set; }
    public DateTime ActivationDate { get; set; }
    public decimal Amount { get; set; }

    public string? ErrorTitle { get; set; }
    public string? ErrorDescription { get; set; }


    public void SetError(string title, string description)
    {
        this.ErrorTitle = title;
        this.ErrorDescription = description;
        this.Status = Status.Error;
    }

    public void SetComplete()
    {
        this.Status = Status.Active;
        this.ActivationDate = DateTime.Now;
    }
}