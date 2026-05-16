using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form_display : Form
    {
        private List<aCandlestick> allCandlesticks;

        public Form_display()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Opens file dialog, checks if it is ok, then calls the function to parse the 
        /// data via stockReader reader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SelectStock_Click(object sender, EventArgs e)
        {
            openFileDialog_SelectStock.ShowDialog();
        }

/// <summary>
/// Handles the FileOk event of the open file dialog by processing the selected stock file and opening additional forms
/// for each selected file.
/// </summary>
/// <remarks>This method processes the first selected file and opens a new display form for each additional file
/// selected in the dialog. It is intended to be used as an event handler for the FileOk event of an OpenFileDialog
/// configured for multiple file selection.</remarks>
/// <param name="sender">The source of the event, typically the OpenFileDialog control.</param>
/// <param name="e">A CancelEventArgs that contains the event data.</param>
        private void openFileDialog_SelectStock_FileOk(object sender, CancelEventArgs e)
        {
            handleSelection(openFileDialog_SelectStock.FileName, dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);
            for (int i = 1; i < openFileDialog_SelectStock.FileNames.Length; i++)
            {
                Form_display newForm = new Form_display(openFileDialog_SelectStock.FileNames[i], dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);
                //newForm.handleSelection(openFileDialog_SelectStock.FileNames[i], dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);
                newForm.Show();
            }
        }

/// <summary>
/// Creates a FOrm_Display using parameters fileName, startDate and endDate to automatically load stock into the form.
/// </summary>
/// <param name="fileName"></param>
/// <param name="startDate"></param>
/// <param name="endDate"></param>
        public Form_display(string fileName, DateTime startDate, DateTime endDate)
        {
            //if (DesignMode) return;

            InitializeComponent();

            //makes form text the .csv that is being loaded
            this.Text = Path.GetFileName(fileName);

            dateTimePicker_StartDate.Value = startDate;
            dateTimePicker_EndDate.Value = endDate;

            handleSelection(fileName, startDate, endDate);
        }

/// <summary>
/// Loads candlestick data from the specified CSV file and filters it by the provided date range.
/// </summary>
/// <remarks>This method does nothing if called in design mode.</remarks>
/// <param name="fileName">The path to the CSV file containing candlestick data. Cannot be null or empty.</param>
/// <param name="startDate">The start date of the range to filter candlestick data. Only data on or after this date is included.</param>
/// <param name="endDate">The end date of the range to filter candlestick data. Only data on or before this date is included.</param>
        private void handleSelection(string fileName, DateTime startDate, DateTime endDate)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            //makes form text the .csv that is being loaded
            this.Text = Path.GetFileName(fileName);

            stockReader reader = new stockReader();
            allCandlesticks = reader.ReadCandlesticksFromCSV(fileName);
            FilterByDate();
        }

/// <summary>
/// Handles the Click event of the Refresh Display button to update the stock data chart with the latest filtered data.
/// </summary>
/// <remarks>Call this method to refresh the chart display after changing filter criteria. The chart is updated
/// with the current filtered data set.</remarks>
/// <param name="sender">The source of the event, typically the Refresh Display button.</param>
/// <param name="e">An EventArgs object that contains the event data.</param>
        private void button_refreshDisplay_Click(object sender, EventArgs e)
        {
            //Calls FilterByDate, and automatically updates the chart at end
            FilterByDate();
            chart_stockDataDisplay.DataSource = aCandlestickBindingSource;
            chart_stockDataDisplay.DataBind();

            this.Button_refreshDisplay.Visible = true;
        }

/// <summary>
/// Filters the candlestick data to include only entries within the selected date range.
/// </summary>
/// <remarks>Updates the data source to reflect the filtered results and makes the refresh display button visible.
/// The date range is determined by the values selected in the start and end date pickers.</remarks>
        private void FilterByDate()
        {
            if (allCandlesticks == null) return;

            DateTime start = dateTimePicker_StartDate.Value.Date;
            DateTime end = dateTimePicker_EndDate.Value.Date;
            var filtered = allCandlesticks
                .Where(c => c.date >= start && c.date <= end)
                .ToList();
            aCandlestickBindingSource.DataSource = filtered;
            this.Button_refreshDisplay.Visible = true;

        }

    }
}