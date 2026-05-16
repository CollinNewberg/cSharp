using Project2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class stockReader
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