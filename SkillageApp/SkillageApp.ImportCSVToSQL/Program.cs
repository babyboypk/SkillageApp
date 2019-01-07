using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace SkillageApp.ImportCSVToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var lstExchanges = new List<Exchanx>();
                var lstStockSymbols = new List<StockSymbol>();

                using (var entities = new SkillageAppEntities())
                {
                    lstExchanges = entities.Exchanges.ToList();
                    lstStockSymbols = entities.StockSymbols.ToList();

                }

                var filePath = $"{Environment.CurrentDirectory}\\Import\\ImportData.csv";
                var connection = ConfigurationManager.ConnectionStrings["SkillageAppEntities"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    using (var reader = new StreamReader(@"D:\\Projects\\Freelancer\\SkillageApp\\SkillageApp.ImportCSVToSQL\\bin\\Debug\\Import\\ImportData.csv"))
                    {
                        Console.WriteLine("******* Importing Data ...... ***********************");
                        using (var csv = new CsvReader(reader))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            StringBuilder sql = new StringBuilder();
                            while (csv.Read())
                            {
                                var exchangeId = lstExchanges.FirstOrDefault(e => e.Code == csv.GetField("exchange")).Id;
                                var StockSymbolId = lstStockSymbols.FirstOrDefault(e => e.Code == csv.GetField("stock_symbol")).Id;

                                var dateStr = csv.GetField("date");
                                var dateStrN = DateTime.ParseExact(dateStr, "d/M/yyyy", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");

                                string query = $"Insert into DailyPrices " +
                                               $"(ExchangeId, StockSymbolId, Date, StockPriceOpen,StockPriceHigh,StockPriceLow,StockPriceClose,StockVolume,StockPriceAdjClose) " +
                                               $"values ({exchangeId}, {StockSymbolId}, '{dateStrN}', {csv.GetField("stock_price_open")}, {csv.GetField("stock_price_high")}, {csv.GetField("stock_price_low")}, {csv.GetField("stock_price_close")}, {csv.GetField("stock_volume")}, {csv.GetField("stock_price_adj_close")})";

                                sql.AppendLine(query);
                            }

                            var sqlCmd = new SqlCommand
                            {
                                Connection = conn,
                                CommandText = sql.ToString(),
                                CommandType = CommandType.Text
                            };
                            sqlCmd.ExecuteNonQuery();
                        }
                       Console.WriteLine("******* Import Data Completed ***********************");
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" \n**************************** Error - " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
