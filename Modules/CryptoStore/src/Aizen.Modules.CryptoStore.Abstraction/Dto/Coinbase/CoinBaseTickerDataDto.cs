namespace Aizen.Modules.CryptoStore.Abstraction;
public class CoinBaseTickerDataDto
{
    public string Type { get; set; }
    public long Sequence { get; set; }
    public string ProductId { get; set; }
    public decimal Price { get; set; }
    public decimal Open24h { get; set; }
    public decimal Volume24h { get; set; }
    public decimal Low24h { get; set; }
    public decimal High24h { get; set; }
    public decimal Volume30d { get; set; }
    public decimal BestBid { get; set; }
    public decimal BestAsk { get; set; }
    public string Side { get; set; }
    public DateTime Time { get; set; }
    public long TradeId { get; set; }
    public decimal LastSize { get; set; }
}