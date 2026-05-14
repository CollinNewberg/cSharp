using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project3
{
    //Form_display class prototype
    public partial class Form_display : Form
    {
        private List<aSmartCandlestick> smartCandlesticks;
        private List<aSmartCandlestick> filteredCandlesticks;
        private List<aRecognizer> recognizers = new List<aRecognizer>();

        // stable mapping between candlestick date and chart point
        private Dictionary<DateTime, DataPoint> chartLookup;

        //default constructor
        public Form_display()
        {
            InitializeComponent();

            initializeRecognizers();

            comboBox_selectPattern.DataSource = recognizers;
            comboBox_selectPattern.DisplayMember = "patternName";
        }

        //Cretes a new form from a filename, startdate, and enddate
        public Form_display(string fileName, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            initializeRecognizers();

            comboBox_selectPattern.DataSource = recognizers;
            comboBox_selectPattern.DisplayMember = "patternName";

            this.Text = Path.GetFileName(fileName);

            dateTimePicker_StartDate.Value = startDate;
            dateTimePicker_EndDate.Value = endDate;

            handleSelection(fileName, startDate, endDate);
        }

        private void button_SelectStock_Click(object sender, EventArgs e)
        {
            openFileDialog_SelectStock.ShowDialog();
        }

        //Handles file selection, initializes stock reader, reads from CSV, and opens new forms for additional files if multiple are selected
        private void openFileDialog_SelectStock_FileOk(object sender, CancelEventArgs e)
        {
            handleSelection(
                openFileDialog_SelectStock.FileName,
                dateTimePicker_StartDate.Value,
                dateTimePicker_EndDate.Value
            );

            for (int i = 1; i < openFileDialog_SelectStock.FileNames.Length; i++)
            {
                Form_display newForm = new Form_display(
                    openFileDialog_SelectStock.FileNames[i],
                    dateTimePicker_StartDate.Value,
                    dateTimePicker_EndDate.Value
                );

                newForm.Show();
            }
        }

        //sets text the the file name, initializes stockreader and reads from CSV
        private void handleSelection(string fileName, DateTime startDate, DateTime endDate)
        {
            if (DesignMode) return;

            this.Text = Path.GetFileName(fileName);

            stockReader reader = new stockReader();
            var raw = reader.ReadCandlesticksFromCSV(fileName);

            smartCandlesticks = raw
                .Select(c => new aSmartCandlestick(c))
                .ToList();

            FilterByDate();

            this.Button_refreshDisplay.Visible = true;
        }

        //Refreshed the chart with new strt and end dates and rebinds the data
        private void button_refreshDisplay_Click(object sender, EventArgs e)
        {
            FilterByDate();

            chart_stockDataDisplay.DataSource = aCandlestickBindingSource;
            chart_stockDataDisplay.DataBind();

            // ensure axis type matches datetime data AFTER DataBind
            chart_stockDataDisplay.ChartAreas[0].AxisY.Minimum =
                chart_stockDataDisplay.ChartAreas[0].AxisY.Minimum;

            chart_stockDataDisplay.ChartAreas[0].AxisY.Maximum =
                chart_stockDataDisplay.ChartAreas[0].AxisY.Maximum;
        }

        /// <summary>
        /// Filters the list of candlesticks by start and end date
        /// </summary>
        private void FilterByDate()
        {
            if (smartCandlesticks == null) return;

            DateTime start = dateTimePicker_StartDate.Value.Date;
            DateTime end = dateTimePicker_EndDate.Value.Date;

            filteredCandlesticks = smartCandlesticks
                .Where(c => c.date >= start && c.date <= end)
                .ToList();

            aCandlestickBindingSource.DataSource = filteredCandlesticks;
        }

        /// <summary>
        /// builds stable mapping between chart points and candlestick data
        /// </summary>
        private void BuildChartLookup()
        {
            chartLookup = new Dictionary<DateTime, DataPoint>();

            var series = chart_stockDataDisplay.Series[0];

            foreach (DataPoint dp in series.Points)
            {
                DateTime date = DateTime.FromOADate(dp.XValue).Date;

                if (!chartLookup.ContainsKey(date))
                {
                    chartLookup.Add(date, dp);
                }
            }
        }

        /// <summary>
        /// Update chart annotations to mark occurrences of the selected candlestick pattern and refresh the chart.
        /// </summary>
        /// <remarks>Clears existing annotations, casts the selected item to an aRecognizer, obtains pattern match indices
        /// from filteredCandlesticks, and for each valid match adds a TextAnnotation anchored to the corresponding DataPoint
        /// resolved via chartLookup. Out-of-range indices and missing lookups are ignored. Calls Invalidate on the chart to
        /// force a redraw.</remarks>
        /// <param name="sender">Source of the event, typically the ComboBox that raised the selection change.</param>
        /// <param name="e">Event arguments for the selection change.</param>
        private void comboBox_selectPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filteredCandlesticks == null)
                return;

            if (comboBox_selectPattern.SelectedItem == null)
                return;

            if (checkBox_clearAnnotations.Checked)
            {
                chart_stockDataDisplay.Annotations.Clear();
            }

            var recognizer = (aRecognizer)comboBox_selectPattern.SelectedItem;

            var matches = recognizer.recognize(filteredCandlesticks);

            var series = chart_stockDataDisplay.Series[0];

            foreach (int i in matches)
            {
                if (i < 0 || i >= filteredCandlesticks.Count)
                    continue;

                var dp = chart_stockDataDisplay.Series[0].Points[i];

                var annotation = new TextAnnotation
                {
                    Text = recognizer.patternName,
                    AnchorDataPoint = dp,
                    AnchorAlignment = System.Drawing.ContentAlignment.TopCenter
                };

                chart_stockDataDisplay.Annotations.Add(annotation);
            }

            chart_stockDataDisplay.Invalidate();
        }

        //Event handler for the checkbox to clear annotations, currently does nothing but can be implemented to clear annotations when checked
        private void checkBox_clearAnnotations_CheckedChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Clears and populates the recognizers collection with predefined candlestick pattern recognizers for marubozu and
        /// engulfing patterns.
        /// </summary>
        /// <remarks>Existing recognizers are removed before adding instances: marubozuRecognizer,
        /// bullishMarubozuRecognizer, bearishMarubozuRecognizer, engulfingRecognizer, bullishEngulfingRecognizer, and
        /// bearishEngulfingRecognizer.</remarks>
        private void initializeRecognizers()
        {
            recognizers.Clear();

            recognizers.Add(new marubozuRecognizer());
            recognizers.Add(new bullishMarubozuRecognizer());
            recognizers.Add(new bearishMarubozuRecognizer());
            recognizers.Add(new engulfingRecognizer());
            recognizers.Add(new bullishEngulfingRecognizer());
            recognizers.Add(new bearishEngulfingRecognizer());
            recognizers.Add(new haramiRecognizer());
            recognizers.Add(new dragonflyDojiRecognizer());
            recognizers.Add(new gravestoneDojiRecognizer());
        }
    }
}