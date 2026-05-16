using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Project3
{
    partial class Form_display
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private IContainer components = null;
        private Button Button_SelectStock;
        private Button Button_refreshDisplay;
        private DateTimePicker dateTimePicker_StartDate;
        private DateTimePicker dateTimePicker_EndDate;
        private OpenFileDialog openFileDialog_SelectStock;
        private Label label_StartDate;
        private Label label_EndDate;
        private BindingSource aCandlestickBindingSource;

        /// <summary>
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Button_SelectStock = new System.Windows.Forms.Button();
            this.Button_refreshDisplay = new System.Windows.Forms.Button();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog_SelectStock = new System.Windows.Forms.OpenFileDialog();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.chart_stockDataDisplay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.aCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox_selectPattern = new System.Windows.Forms.ComboBox();
            this.label_selectPattern = new System.Windows.Forms.Label();
            this.checkBox_clearAnnotations = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockDataDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_SelectStock
            // 
            this.Button_SelectStock.Location = new System.Drawing.Point(403, 523);
            this.Button_SelectStock.Name = "Button_SelectStock";
            this.Button_SelectStock.Size = new System.Drawing.Size(127, 48);
            this.Button_SelectStock.TabIndex = 0;
            this.Button_SelectStock.Text = "Select Stock";
            this.Button_SelectStock.UseVisualStyleBackColor = true;
            this.Button_SelectStock.Click += new System.EventHandler(this.button_SelectStock_Click);
            // 
            // Button_refreshDisplay
            // 
            this.Button_refreshDisplay.Location = new System.Drawing.Point(808, 519);
            this.Button_refreshDisplay.Name = "Button_refreshDisplay";
            this.Button_refreshDisplay.Size = new System.Drawing.Size(127, 52);
            this.Button_refreshDisplay.TabIndex = 6;
            this.Button_refreshDisplay.Text = "Update";
            this.Button_refreshDisplay.UseVisualStyleBackColor = true;
            this.Button_refreshDisplay.Visible = false;
            this.Button_refreshDisplay.Click += new System.EventHandler(this.button_refreshDisplay_Click);
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(180, 534);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_StartDate.TabIndex = 2;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2021, 1, 28, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(602, 534);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_EndDate.TabIndex = 3;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2021, 2, 28, 0, 0, 0, 0);
            // 
            // openFileDialog_SelectStock
            // 
            this.openFileDialog_SelectStock.FileName = "ABBV_daily";
            this.openFileDialog_SelectStock.Filter = "All|*.csv|Yearly|*_yearly.csv|Monthly|*_monthly.csv|Weekly|*_weekly.csv|Daily|*_d" +
    "aily.csv";
            this.openFileDialog_SelectStock.Multiselect = true;
            this.openFileDialog_SelectStock.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_SelectStock_FileOk);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Location = new System.Drawing.Point(125, 534);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(37, 16);
            this.label_StartDate.TabIndex = 4;
            this.label_StartDate.Text = "Start:";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Location = new System.Drawing.Point(551, 534);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(34, 16);
            this.label_EndDate.TabIndex = 5;
            this.label_EndDate.Text = "End:";
            // 
            // chart_stockDataDisplay
            // 
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_stockDataDisplay.ChartAreas.Add(chartArea1);
            this.chart_stockDataDisplay.ChartAreas.Add(chartArea2);
            this.chart_stockDataDisplay.DataSource = this.aCandlestickBindingSource;
            legend1.Name = "Legend1";
            this.chart_stockDataDisplay.Legends.Add(legend1);
            this.chart_stockDataDisplay.Location = new System.Drawing.Point(41, 21);
            this.chart_stockDataDisplay.Name = "chart_stockDataDisplay";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=0\\, 192\\, 0";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "high, low, open, close";
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart_stockDataDisplay.Series.Add(series1);
            this.chart_stockDataDisplay.Series.Add(series2);
            this.chart_stockDataDisplay.Size = new System.Drawing.Size(1064, 330);
            this.chart_stockDataDisplay.TabIndex = 7;
            this.chart_stockDataDisplay.Text = "chart1";
            // 
            // aCandlestickBindingSource
            // 
            this.aCandlestickBindingSource.DataSource = typeof(Project3.aCandlestick);
            // 
            // comboBox_selectPattern
            // 
            this.comboBox_selectPattern.FormattingEnabled = true;
            this.comboBox_selectPattern.Location = new System.Drawing.Point(912, 384);
            this.comboBox_selectPattern.Name = "comboBox_selectPattern";
            this.comboBox_selectPattern.Size = new System.Drawing.Size(172, 24);
            this.comboBox_selectPattern.TabIndex = 8;
            this.comboBox_selectPattern.SelectedIndexChanged += new System.EventHandler(this.comboBox_selectPattern_SelectedIndexChanged);
            // 
            // label_selectPattern
            // 
            this.label_selectPattern.AutoSize = true;
            this.label_selectPattern.Location = new System.Drawing.Point(948, 365);
            this.label_selectPattern.Name = "label_selectPattern";
            this.label_selectPattern.Size = new System.Drawing.Size(90, 16);
            this.label_selectPattern.TabIndex = 9;
            this.label_selectPattern.Text = "Select Pattern";
            // 
            // checkBox_clearAnnotations
            // 
            this.checkBox_clearAnnotations.AutoSize = true;
            this.checkBox_clearAnnotations.Location = new System.Drawing.Point(857, 414);
            this.checkBox_clearAnnotations.Name = "checkBox_clearAnnotations";
            this.checkBox_clearAnnotations.Size = new System.Drawing.Size(290, 20);
            this.checkBox_clearAnnotations.TabIndex = 10;
            this.checkBox_clearAnnotations.Text = "Clear annotations prior to displaying new set";
            this.checkBox_clearAnnotations.UseVisualStyleBackColor = true;
            this.checkBox_clearAnnotations.CheckedChanged += new System.EventHandler(this.checkBox_clearAnnotations_CheckedChanged);
            // 
            // Form_display
            // 
            this.ClientSize = new System.Drawing.Size(1180, 599);
            this.Controls.Add(this.checkBox_clearAnnotations);
            this.Controls.Add(this.label_selectPattern);
            this.Controls.Add(this.comboBox_selectPattern);
            this.Controls.Add(this.chart_stockDataDisplay);
            this.Controls.Add(this.Button_refreshDisplay);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.Button_SelectStock);
            this.Name = "Form_display";
            this.Text = "Stock Display";
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockDataDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockDataDisplay;
        private ComboBox comboBox_selectPattern;
        private Label label_selectPattern;
        private CheckBox checkBox_clearAnnotations;
    }
}