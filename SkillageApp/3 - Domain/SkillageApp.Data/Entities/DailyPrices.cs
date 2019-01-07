using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillageApp.Infrastructure.SharedKernel;

namespace SkillageApp.Data.Entities
{
    [Table("DailyPrices")]
    public class DailyPrices : DomainEntity<int>
    {
        #region Contrusctor

        public DailyPrices()
        {

        }

        public DailyPrices(
            int exchangeId, int stockSymbolId, DateTime date, double stockPriceOpen,
            double stockPriceHigh, double stockPriceLow, double stockPriceClose,
            long stockVolume, double stockPriceAdjClose
        )
        {
            ExchangeId = exchangeId;
            StockSymbolId = stockSymbolId;
            Date = date;
            StockPriceOpen = stockPriceOpen;
            StockPriceHigh = stockPriceHigh;
            StockPriceLow = stockPriceLow;
            StockPriceClose = stockPriceClose;
            StockVolume = stockVolume;
            StockPriceAdjClose = stockPriceAdjClose;
        }

        public DailyPrices(int id,
            int exchangeId, int stockSymbolId, DateTime date, double stockPriceOpen,
            double stockPriceHigh, double stockPriceLow, double stockPriceClose,
            long stockVolume, double stockPriceAdjClose
        )
        {
            Id = id;
            ExchangeId = exchangeId;
            StockSymbolId = stockSymbolId;
            Date = date;
            StockPriceOpen = stockPriceOpen;
            StockPriceHigh = stockPriceHigh;
            StockPriceLow = stockPriceLow;
            StockPriceClose = stockPriceClose;
            StockVolume = stockVolume;
            StockPriceAdjClose = stockPriceAdjClose;
        }

        #endregion

        [Required]
        public int ExchangeId { get; set; }

        [Required]
        public int StockSymbolId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double StockPriceOpen { get; set; }

        [Required]
        public double StockPriceHigh { get; set; }

        [Required]
        public double StockPriceLow { get; set; }

        [Required]
        public double StockPriceClose { get; set; }

        [Required]
        public long StockVolume { get; set; }

        [Required]
        public double StockPriceAdjClose { get; set; }


        [ForeignKey("ExchangeId")]
        public virtual Exchange Exchange { set; get; }

        [ForeignKey("StockSymbolId")]
        public virtual StockSymbol StockSymbol { set; get; }
    }
}