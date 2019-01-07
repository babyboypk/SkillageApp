namespace SkillageApp.WinFormsApp
{
    partial class MainForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.rgvExchangeDailyPrices = new Telerik.WinControls.UI.RadGridView();
            this.radDesktopAlertMain = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
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
            this.rgvExchangeDailyPrices.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgvExchangeDailyPrices.Name = "rgvExchangeDailyPrices";
            this.rgvExchangeDailyPrices.Size = new System.Drawing.Size(947, 345);
            this.rgvExchangeDailyPrices.TabIndex = 0;
            this.rgvExchangeDailyPrices.ThemeName = "Windows8";
            this.rgvExchangeDailyPrices.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.rgvExchangeDailyPrices_CellFormatting);
            this.rgvExchangeDailyPrices.EditorRequired += new Telerik.WinControls.UI.EditorRequiredEventHandler(this.rgvExchangeDailyPrices_EditorRequired);
            this.rgvExchangeDailyPrices.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvExchangeDailyPrices_CellValueChanged);
            // 
            // radDesktopAlertMain
            // 
            this.radDesktopAlertMain.CanMove = false;
            this.radDesktopAlertMain.ThemeName = "Windows8";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 370);
            this.Controls.Add(this.rgvExchangeDailyPrices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
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
    }
}