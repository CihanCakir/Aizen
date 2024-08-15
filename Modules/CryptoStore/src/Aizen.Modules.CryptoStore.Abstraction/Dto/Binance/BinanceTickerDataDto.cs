using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aizen.Modules.CryptoStore.Abstraction;
public class BinanceTickerDataDto
{
    public string e { get; set; }  // Event type (örneğin, "24hrTicker")
    public long E { get; set; }    // Event time (Unix timestamp formatında)
    public string s { get; set; }  // Symbol (örneğin, "BTCUSDT")
    public string p { get; set; }  // Price change (Son 24 saatteki fiyat değişimi)
    public string P { get; set; }  // Price change percent (Son 24 saatteki fiyat değişim yüzdesi)
    public string w { get; set; }  // Weighted average price (Ağırlıklı ortalama fiyat)
    public string x { get; set; }  // Previous day's close price (Bir önceki gün kapanış fiyatı)
    public string c { get; set; }  // Last price (Son işlem fiyatı)
    public string Q { get; set; }  // Last quantity (Son işlem miktarı)
    public string b { get; set; }  // Best bid price (En iyi alış fiyatı)
    public string B { get; set; }  // Best bid quantity (En iyi alış miktarı)
    public string a { get; set; }  // Best ask price (En iyi satış fiyatı)
    public string A { get; set; }  // Best ask quantity (En iyi satış miktarı)
    public string o { get; set; }  // Open price (Açılış fiyatı)
    public string h { get; set; }  // High price (En yüksek fiyat)
    public string l { get; set; }  // Low price (En düşük fiyat)
    public string v { get; set; }  // Total traded base asset volume (Toplam işlem gören temel varlık hacmi)
    public string q { get; set; }  // Total traded quote asset volume (Toplam işlem gören kote varlık hacmi)
}

public class BinanceTickerStreamDto
{
    public string stream { get; set; }  // Stream name (örneğin, "btcusdt@ticker" veya "ethusdt@ticker")
    public BinanceTickerDataDto data { get; set; } // Ticker data (BTCUSDT veya ETHUSDT için ilgili fiyat ve hacim bilgileri)
}