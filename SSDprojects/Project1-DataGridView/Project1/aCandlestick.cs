using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Project1

{
    public class aCandlestick
    {
        public DateTime date { get; set; }
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal close { get; set; }
        public ulong volume { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public aCandlestick() { }


        public aCandlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, ulong volume)
        {
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }


        /// <summary>
        /// copy constructor
        /// clone new candlestick from source
        /// </summary>
        /// <param name="sourceCandlestick"></param>
        public aCandlestick(aCandlestick sourceCandlestick)
        {
            date = sourceCandlestick.date;
            open = sourceCandlestick.open;
            high = sourceCandlestick.high;
            low = sourceCandlestick.low;
            close = sourceCandlestick.close;
            volume = sourceCandlestick.volume;
        }


        /// <summary>
        /// Constructor to build cS from string from .csv file
        /// </summary>
        /// <param name="line"></param>
        public aCandlestick(String line)
        {
            //use both comma and double quotes as seperators
            //var seperators = new char[] {',', '\t'}; --done in class - not to format of csv
            var values = line.Split(',');

            if (values.Length < 6)
            {
                throw new ArgumentException("Invalid data format. Expected 5 values seperated by commas and double quotes.");
            }
            //forced to correct date/time parser due to added values in the csv (into ISO 8601 --whatever that is)
            date = DateTime.Parse(values[0].Trim('"'),CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            //Math.Round to round to 2 digits
            open = Math.Round(decimal.Parse(values[1]), 2);
            high = Math.Round(decimal.Parse(values[2]), 2);
            low = Math.Round(decimal.Parse(values[3]), 2);
            close = Math.Round(decimal.Parse(values[4]), 2);
            volume = ulong.Parse(values[5]);

        }

    }
}
