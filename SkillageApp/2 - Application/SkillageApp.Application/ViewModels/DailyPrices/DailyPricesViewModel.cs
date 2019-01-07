using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillageApp.App.ViewModels
{
    public class DailyPricesViewModel
    {
        public  int Id { get; set; }
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
    }
}
