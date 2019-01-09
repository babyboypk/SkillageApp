namespace SkillageApp.WinAppToAPI
{
    partial class RadMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.rgvExchangeDailyPrices = new Telerik.WinControls.UI.RadGridView();
            this.radDesktopAlertMain = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
            this.dotsLineWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this.rgvExchangeDailyPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvExchangeDailyPrices.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvExchangeDailyPrices
            // 
            this.rgvExchangeDailyPrices.Location = new System.Drawing.Point(13, 13);
            // 
            // 
            // 
            this.rgvExchangeDailyPrices.MasterTemplate.AllowAddNewRow = false;
            this.rgvExchangeDailyPrices.MasterTemplate.AllowDeleteRow = false;
            this.rgvExchangeDailyPrices.MasterTemplate.AllowSearchRow = true;
            this.rgvExchangeDailyPrices.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rgvExchangeDailyPrices.MasterTemplate.EnableGrouping = false;
            this.rgvExchangeDailyPrices.MasterTemplate.EnablePaging = true;
            this.rgvExchangeDailyPrices.MasterTemplate.PageSize = 1000;
            this.rgvExchangeDailyPrices.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvExchangeDailyPrices.Name = "rgvExchangeDailyPrices";
            this.rgvExchangeDailyPrices.Size = new System.Drawing.Size(1167, 420);
            this.rgvExchangeDailyPrices.TabIndex = 0;
            this.rgvExchangeDailyPrices.ThemeName = "Windows8";
            this.rgvExchangeDailyPrices.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.rgvExchangeDailyPrices_CellFormatting);
            this.rgvExchangeDailyPrices.EditorRequired += new Telerik.WinControls.UI.EditorRequiredEventHandler(this.rgvExchangeDailyPrices_EditorRequired);
            this.rgvExchangeDailyPrices.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvExchangeDailyPrices_CellValueChanged);
            // 
            // radDesktopAlertMain
            // 
            this.radDesktopAlertMain.ThemeName = "Windows8";
            // 
            // dotsLineWaitingBarIndicatorElement1
            // 
            this.dotsLineWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsLineWaitingBarIndicatorElement1.Name = "dotsLineWaitingBarIndicatorElement1";
            this.dotsLineWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsLineWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // RadMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 445);
            this.Controls.Add(this.rgvExchangeDailyPrices);
            this.Name = "RadMainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "NYSE Daily Prices";
            this.ThemeName = "Windows8";
            ((System.ComponentModel.ISupportInitialize)(this.rgvExchangeDailyPrices.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvExchangeDailyPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.RadGridView rgvExchangeDailyPrices;
        private Telerik.WinControls.UI.RadDesktopAlert radDesktopAlertMain;
        private Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement dotsLineWaitingBarIndicatorElement1;
    }
}