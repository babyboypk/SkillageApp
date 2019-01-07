using System;
using System.Collections.Generic;
using System.Linq;
using SkillageApp.App.Interfaces;
using SkillageApp.App.ViewModels;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SkillageApp.WinFormsApp
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        #region Properties

        private readonly IExchangeService _exchangeService;
        private readonly IStockSymbolService _stockSymbolService;
        private readonly IDailyPricesService _dailyPricesService;
        private List<DailyPricesViewModel> lstDailyPricesVM;
        private List<ExchangeViewModel> lstExchangeVM;
        private List<StockSymbolViewModel> lstStockSymbolVM;
        
        #endregion

        public MainForm(
            IExchangeService exchangeService, 
            IStockSymbolService stockSymbolService, 
            IDailyPricesService dailyPricesService)
        {
            _exchangeService = exchangeService;
            _stockSymbolService = stockSymbolService;
            _dailyPricesService = dailyPricesService;

            InitializeComponent();

            LoadDataForGridView();
            LoadConfigDataGridView();
        }

        /// <summary>
        /// Load Data from Database
        /// </summary>
        private void LoadDataForGridView()
        {
            lstDailyPricesVM = _dailyPricesService.GetAll();
            lstExchangeVM = _exchangeService.GetAll();
            lstStockSymbolVM = _stockSymbolService.GetAll();
        }

        /// <summary>
        /// Load Config For Data Grid
        /// </summary>
        private void LoadConfigDataGridView()
        {
            rgvExchangeDailyPrices.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            rgvExchangeDailyPrices.DataSource = lstDailyPricesVM;
            rgvExchangeDailyPrices.EnableFiltering = false;
            rgvExchangeDailyPrices.AllowAddNewRow = false;
            rgvExchangeDailyPrices.EnablePaging = true;
            rgvExchangeDailyPrices.PageSize = 1000;

            rgvExchangeDailyPrices.Columns["Id"].IsVisible = false;

            rgvExchangeDailyPrices.Columns["ExchangeId"].HeaderText = "Exchange";
            rgvExchangeDailyPrices.Columns["StockSymbolId"].HeaderText = "Stock Symbol";
            rgvExchangeDailyPrices.Columns["Date"].HeaderText = "Date";
            rgvExchangeDailyPrices.Columns["StockPriceOpen"].HeaderText = "Stock Price Open";
            rgvExchangeDailyPrices.Columns["StockPriceHigh"].HeaderText = "Stock Price High";
            rgvExchangeDailyPrices.Columns["StockPriceLow"].HeaderText = "StockPriceLow";
            rgvExchangeDailyPrices.Columns["StockPriceClose"].HeaderText = "Stock Price Close";
            rgvExchangeDailyPrices.Columns["StockVolume"].HeaderText = "Stock Volume";
            rgvExchangeDailyPrices.Columns["StockPriceAdjClose"].HeaderText = "Stock Price Adj Close";
        }

        /// <summary>
        /// Format Cell Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rgvExchangeDailyPrices_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            var columnName = e.CellElement.ColumnInfo.Name;
            switch (columnName)
            {
                case "ExchangeId":
                    if (e.CellElement.Value != null && e.CellElement.Value != DBNull.Value)
                    {
                        var exchange = lstExchangeVM.FirstOrDefault(x => x.Id == (int)e.CellElement.Value);
                        e.CellElement.Text = exchange.Name;
                    }
                    break;

                case "StockSymbolId":
                    if (e.CellElement.Value != null && e.CellElement.Value != DBNull.Value)
                    {
                        var stockSymbol = lstStockSymbolVM.FirstOrDefault(x => x.Id == (int)e.CellElement.Value);
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

        /// <summary>
        /// Set Editor type for cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rgvExchangeDailyPrices_EditorRequired(object sender, EditorRequiredEventArgs e)
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
                        ddlElement.DataSource = lstExchangeVM;
                    }
                    else
                    {
                        ddlElement.DataSource = lstStockSymbolVM;
                    }
                    ddlElement.DisplayMember = "Name";
                    ddlElement.ValueMember = "Id";
                    e.Editor = ddlEditor;
                    break;
            }
        }

        /// <summary>
        /// Get Data changed and save database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rgvExchangeDailyPrices_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            var name = e.Column.Name;
            var id = Convert.ToInt32(rgvExchangeDailyPrices.CurrentRow.Cells["Id"].Value);
            var exchangeDailyPriceVM = _dailyPricesService.GetById(id);

            var value = e.Value;
            switch (name)
            {
                case "ExchangeId":
                    exchangeDailyPriceVM.ExchangeId = Convert.ToInt32(e.Value);
                    break;
                case "StockSymbolId":
                    exchangeDailyPriceVM.StockSymbolId = Convert.ToInt32(e.Value);
                    break;
                case "Date":
                    exchangeDailyPriceVM.Date = Convert.ToDateTime(e.Value);
                    break;
                case "StockPriceOpen":
                    exchangeDailyPriceVM.StockPriceOpen = Convert.ToDouble(e.Value);
                    break;
                case "StockPriceHigh":
                    exchangeDailyPriceVM.StockPriceHigh = Convert.ToDouble(e.Value);
                    break;
                case "StockPriceLow":
                    exchangeDailyPriceVM.StockPriceLow = Convert.ToDouble(e.Value);
                    break;
                case "StockPriceClose":
                    exchangeDailyPriceVM.StockPriceClose = Convert.ToDouble(e.Value);
                    break;
                case "StockVolume":
                    exchangeDailyPriceVM.StockVolume = Convert.ToInt64(e.Value);
                    break;
                case "StockPriceAdjClose":
                    exchangeDailyPriceVM.StockPriceAdjClose = Convert.ToDouble(e.Value);
                    break;
            }
            _dailyPricesService.Update(exchangeDailyPriceVM);
            _dailyPricesService.SaveChanges();

            radDesktopAlertMain.CaptionText = "Update Data";
            radDesktopAlertMain.ContentText = "Update Exchange Daily Prices Successfully.";
            radDesktopAlertMain.Show();
        }
    }
}
