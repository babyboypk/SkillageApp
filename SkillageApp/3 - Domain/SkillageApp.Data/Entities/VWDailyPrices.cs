using System;
using System.ComponentModel.DataAnnotations.Schema;
using SkillageApp.Infrastructure.SharedKernel;

namespace SkillageApp.Data.Entities
{
    [Table("VW_DailyPrices")]
    public class VWDailyPrices : DomainEntity<int>
    {
        public string Exchange { get; set; }
        public string StockSymbol { get; set; }
        public DateTime Date { get; set; }
        public double StockPriceOpen { get; set; }
        public double StockPriceHigh { get; set; }
        public double StockPriceLow { get; set; }
        public double StockPriceClose { get; set; }
        public long StockVolume { get; set; }
        public double StockPriceAdjClose { get; set; }
    }
}