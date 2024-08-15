using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aizen.Modules.CryptoStore.Abstraction;
public class BtcTurkTickerDataDto
{
    public string Pair { get; set; } // Örneğin: "BTCTRY"
    public decimal Last { get; set; } // Son fiyat
    public decimal High { get; set; } // Günün en yüksek fiyatı
    public decimal Low { get; set; } // Günün en düşük fiyatı
    public decimal Bid { get; set; } // Alış (bid) fiyatı
    public decimal Ask { get; set; } // Satış (ask) fiyatı
    public decimal Volume { get; set; } // Günlük işlem hacmi
    public long Timestamp { get; set; } // Zaman damgası (Unix time formatında)
}