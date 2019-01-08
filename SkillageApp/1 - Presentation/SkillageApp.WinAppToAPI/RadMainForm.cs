using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using RestSharp;
using SkillageApp.WinAppToAPI.ViewModels;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SkillageApp.WinAppToAPI
{
    public partial class RadMainForm : Telerik.WinControls.UI.RadForm
    {
        static string urlWebApi = ConfigurationManager.AppSettings["WebApiUrl"];

        private List<ExchangeViewModel> lstExchange;
        private List<StockSymbolViewModel> lstStockSymbol;
        private List<DailyPricesViewModel> lstDailyPrices;

        public RadMainForm()
        {
            InitializeComponent();

            LoadDataExchange();
            LoadDataStockSymbol();
            LoadDataDailyPrices();

            LoadConfigDataGridView();
        }

        private void LoadDataExchange()
        {
            var client = new RestClient(urlWebApi);
            var request = new RestRequest("exchange/getAll", Method.GET);

            var response = client.Execute<List<ExchangeViewModel>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                lstExchange = response.Data;
            }
        }

        private void LoadDataStockSymbol()
        {
            var client = new RestClient(urlWebApi);
            var request = new RestRequest("stockSymbol/getAll", Method.GET);

            var response = client.Execute<List<StockSymbolViewModel>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                lstStockSymbol = response.Data;
            }
        }

        private void LoadDataDailyPrices()
        {
            var client = new RestClient(urlWebApi);
            var request = new RestRequest("dailyPrices/getAll", Method.GET);

            var response = client.Execute<List<DailyPricesViewModel>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                lstDailyPrices = response.Data;
            }
        }

        private void LoadConfigDataGridView()
        {
            rgvExchangeDailyPrices.DataSource = lstDailyPrices;

            rgvExchangeDailyPrices.Columns["Id"].IsVisible = false;
            rgvExchangeDailyPrices.Columns["ExchangeId"].HeaderText = "Exchange";
            rgvExchangeDailyPrices.Columns["StockSymbolId"].HeaderText = "Stock Symbol";
            rgvExchangeDailyPrices.Columns["Date"].HeaderText = "Date";
            rgvExchangeDailyPrices.Columns["StockPriceOpen"].HeaderText = "Stock Price Open";
            rgvExchangeDailyPrices.Columns["StockPriceHigh"].HeaderText = "Stock Price High";
            rgvExchangeDailyPrices.Columns["StockPriceLow"].HeaderText = "Stock Price Low";
            rgvExchangeDailyPrices.Columns["StockPriceClose"].HeaderText = "Stock Price Close";
            rgvExchangeDailyPrices.Columns["StockVolume"].HeaderText = "Stock Volume";
            rgvExchangeDailyPrices.Columns["StockPriceAdjClose"].HeaderText = "Stock Price Adj Close";
        }

        private void rgvExchangeDailyPrices_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            var columnName = e.CellElement.ColumnInfo.Name;
            switch (columnName)
            {
                case "ExchangeId":
                    if (e.CellElement.Value != null && e.CellElement.Value != DBNull.Value)
                    {
                        var exchange = lstExchange.FirstOrDefault(x => x.Id == (int)e.CellElement.Value);
                        e.CellElement.Text = exchange.Name;
                    }
                    break;

                case "StockSymbolId":
                    if (e.CellElement.Value != null && e.CellElement.Value != DBNull.Value)
                    {
                        var stockSymbol = lstStockSymbol.FirstOrDefault(x => x.Id == (int)e.CellElement.Value);
                        e.CellElement.Text = stockSymbol.Name;
                    }
                    break;

                case "Date":
                    if (e.CellElement.Value != null && e.CellElement.Value != DBNull.Value)
                    {

                        DateTime value = DateTime.Parse(e.CellElement.Value.ToString());
                        e.CellElement.Text = value.ToString("dd/MM/yyyy");
                    }
                    break;

            }
        }

        private void rgvExchangeDailyPrices_EditorRequired(object sender, Telerik.WinControls.UI.EditorRequiredEventArgs e)
        {
            var columnName = rgvExchangeDailyPrices.CurrentCell.ColumnInfo.Name;
            switch (columnName)
            {
                case "ExchangeId":
                case "StockSymbolId":
                    var ddlEditor = new RadDropDownListEditor();
                    var ddlElement = ddlEditor.EditorElement as RadDropDownListEditorElement;
                    ddlElement.DropDownStyle = RadDropDownStyle.DropDownList;

                    if (columnName == "ExchangeId")
                    {
                        ddlElement.DataSource = lstExchange;
                    }
                    else
                    {
                        ddlElement.DataSource = lstStockSymbol;
                    }
                    ddlElement.DisplayMember = "Name";
                    ddlElement.ValueMember = "Id";
                    e.Editor = ddlEditor;
                    break;
            }
        }

        private void rgvExchangeDailyPrices_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var columnName = e.Column.Name;
            var id = Convert.ToInt32(rgvExchangeDailyPrices.CurrentRow.Cells["Id"].Value);
            var model = lstDailyPrices.FirstOrDefault(x => x.Id == id);

            var value = e.Value;
            switch (columnName)
            {
                case "ExchangeId":
                    model.ExchangeId = Convert.ToInt32(e.Value);
                    break;
                case "StockSymbolId":
                    model.StockSymbolId = Convert.ToInt32(e.Value);
                    break;
                case "Date":
                    model.Date = Convert.ToDateTime(e.Value);
                    break;
                case "StockPriceOpen":
                    model.StockPriceOpen = Convert.ToDouble(e.Value);
                    break;
                case "StockPriceHigh":
                    model.StockPriceHigh = Convert.ToDouble(e.Value);
                    break;
                case "StockPriceLow":
                    model.StockPriceLow = Convert.ToDouble(e.Value);
                    break;
                case "StockPriceClose":
                    model.StockPriceClose = Convert.ToDouble(e.Value);
                    break;
                case "StockVolume":
                    model.StockVolume = Convert.ToInt64(e.Value);
                    break;
                case "StockPriceAdjClose":
                    model.StockPriceAdjClose = Convert.ToDouble(e.Value);
                    break;
            }

            var client = new RestClient(urlWebApi);
            var request = new RestRequest("dailyPrices/update", Method.PUT, DataFormat.Json);
            
            request.AddJsonBody(model);

            // execute the request
            var response = client.Execute(request);

            radDesktopAlertMain.CaptionText = "Update Data";

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    radDesktopAlertMain.ContentText = "Update Exchange Daily Prices Successfully.";
                    break;
                default:
                    radDesktopAlertMain.ContentText = "Please check the data again.";
                    break;
            }
            
            radDesktopAlertMain.Show();
        }
    }
}
