using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        private List<aCandlestick> allCandlesticks;

        public Form1()
        {
            InitializeComponent();

            //Hooks update button
            this.button_UpdateGrid.Click += button_UpdateGrid_Click;
        }

/// <summary>
/// Opens file dialog, checks if it is ok, then calls the function to parse the 
/// data via stockReader reader
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button_SelectStock_Click(object sender, EventArgs e)
        {
            if (openFileDialog_SelectStock.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog_SelectStock.FileName;
                StockReader reader = new StockReader();
                allCandlesticks = reader.ReadCandlesticksFromCSV(fileName);
                FilterByDate();
            }
        }

        private void button_UpdateGrid_Click(object sender, EventArgs e)
        {
            //Calls FilterByDate, and automatically updates the datagridview at end
            FilterByDate();
        }

       /// <summary>
       /// 
       /// </summary>
        private void FilterByDate()
        {
            if (allCandlesticks == null) return;

            DateTime start = dateTimePicker_StartDate.Value.Date;
            DateTime end = dateTimePicker_EndDate.Value.Date;

            var filtered = allCandlesticks
                .Where(c => c.date >= start && c.date <= end)
                .ToList();

            aCandlestickBindingSource.DataSource = filtered;
        }

        private void openFileDialog_SelectStock_FileOk(object sender, CancelEventArgs e)
        {
            // Not needed; handled in button_SelectStock_Click
        }
    }

    public class StockReader
    {
        /// <summary>
        /// Reads csv from filepath and returns candlesticks
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public List<aCandlestick> ReadCandlesticksFromCSV(string filepath)
        {
            var candlesticks = new List<aCandlestick>();
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine();//skip header
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var candlestick = new aCandlestick(line);
                    candlesticks.Add(candlestick);
                }
            }
            return candlesticks;
        }
    }
}