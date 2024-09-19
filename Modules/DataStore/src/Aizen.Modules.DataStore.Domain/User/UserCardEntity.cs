using Aizen.Core.Domain;
using Aizen.Core.Domain.Abstraction;

namespace Aizen.Modules.DataStore.Domain
{
    public class UserCardEntity : AizenEntity, IAizenAggregateRoot
    {
        public string? MobilePhone { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }

        public string? CardNo { get; set; }

        public string? Pin { get; set; }
        public int ParentID { get; set; }

        public int? FalsePin { get; set; }
        public int? Statu { get; set; }

        public decimal? Balance { get; set; }
        public decimal? Balance2 { get; set; }
        public decimal? Balance3 { get; set; }
        public decimal? Balance4 { get; set; }
        public decimal? Balance5 { get; set; }
        public decimal? Balance6 { get; set; }
        public decimal? Balance7 { get; set; }
        public decimal? Balance8 { get; set; }
        public decimal? Balance9 { get; set; }
        public decimal? Balance10 { get; set; }
        public string? Password { get; set; }
        public string? enPin { get; set; }
        public string? eMail { get; set; }
        public string? Code01 { get; set; }
        public string? Code02 { get; set; }
        public string? Code03 { get; set; }
        public string? Code04 { get; set; }
        public string? Code05 { get; set; }
        public string? Code06 { get; set; }
        public string? Code07 { get; set; }
        public string? Code08 { get; set; }
        public string? Code09 { get; set; }
        public string? Code10 { get; set; }
        public string? Code11 { get; set; }
        public string? Code12 { get; set; }
        public decimal? Limit { get; set; }
        public int? TekilKullanimAdet { get; set; }
        public int? ToplamKullanimAdet { get; set; }
        public int KartDurum { get; set; }
        public int? Ekleyen { get; set; }
        public int? Duzenleyen { get; set; }
        public string? CardID { get; set; }
        public decimal? LBalance { get; set; }
        public decimal? LBalance2 { get; set; }
        public decimal? LBalance3 { get; set; }
        public decimal? LBalance4 { get; set; }
        public decimal? LBalance5 { get; set; }
        public decimal? LBalance6 { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? Token_thru { get; set; } //date
        public string? Token_Key { get; set; }
        public string? Mobile_Token_Key { get; set; }
        public DateTime? Mobil_Token_thru { get; set; }
        public string? Aciklama { get; set; }
        public decimal? tBalance { get; set; }
        public decimal? tBalance3 { get; set; }
        public decimal? tBalance4 { get; set; }
        public decimal? tBalance5 { get; set; }
        public decimal? tBalance6 { get; set; }
        public decimal? addBalance { get; set; }
        public DateTime? lastPinChange { get; set; }
        public decimal PrimBalance { get; set; }
        public string? PrimKodu { get; set; }
        public string? BaseJson { get; set; }
        public string? RefNo { get; set; }
        public int ChannelPermission { get; set; }
        public int ChannelNeedPassword { get; set; }
        public int? IssuerId { get; set; }
        public int? CardTypeId { get; set; }
        public DateTime? PrintDate { get; set; }
        public byte? DeliveryStatus { get; set; }
        public DateTime? BalanceChangeDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? CardAlias { get; set; }
        public bool? IsStockCard { get; set; }
        public int? AuthenticationOption { get; set; }
        public bool? IsClosedLoad { get; set; }
        public int? LoadReasonStateLookUpId { get; set; }
        public DateTime? LoadReasonStateDate { get; set; }
        public string? CostCenterCode { get; set; }
        public string? RegisterReferenceNo { get; set; }
        public int? CardOwnerTypeId { get; set; }
        public DateTime? LastLoadedTime { get; set; }
        public DateTime? LastTransactionTime { get; set; }
        public bool? IsPhoto { get; set; }
        public bool? IsMifare { get; set; }
        public bool? IsMagnetic { get; set; }
        public bool? IsMagneticMifare { get; set; }
        public bool? IsMagneticMifareChip { get; set; }
        public string? CompanyCode { get; set; } = "";
        public bool VisibleCardInfo { get; set; }
        public bool? IsPassPayActive { get; set; }
        public int? CVV { get; set; }
    }
}