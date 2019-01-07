using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillageApp.App.ViewModels
{
    public class VWDailyPricesViewModel
    {
        public  int Id { get; set; }
        public string Exchange { get; set; }

        public string StockSymbol { get; set; }

        public DateTime Date { get; set; }
        public string DateText { get; set; }

        public double StockPriceOpen { get; set; }

        public double StockPriceHigh { get; set; }

        public double StockPriceLow { get; set; }

        public double StockPriceClose { get; set; }

        public long StockVolume { get; set; }

        public double StockPriceAdjClose { get; set; }
    }
}
