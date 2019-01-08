using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillageApp.WinAppToAPI.ViewModels
{
    public class DailyPricesViewModel
    {
        public  int Id { get; set; }
        public int ExchangeId { get; set; }
        public int StockSymbolId { get; set; }
        public DateTime Date { get; set; }
        public double StockPriceOpen { get; set; }
        public double StockPriceHigh { get; set; }
        public double StockPriceLow { get; set; }
        public double StockPriceClose { get; set; }
        public long StockVolume { get; set; }
        public double StockPriceAdjClose { get; set; }
    }
}
