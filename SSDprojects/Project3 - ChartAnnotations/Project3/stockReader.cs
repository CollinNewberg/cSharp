using Project3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
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

/// <summary>
/// Reads a CSV file and returns a list of smart candlestick objects parsed from its contents.
/// </summary>
/// <remarks>The first line of the CSV file is assumed to be a header and is skipped. Each subsequent non-empty
/// line is parsed into a smart candlestick object. The method does not validate the format of each line beyond
/// non-emptiness; malformed lines may cause exceptions when constructing smart candlestick objects.</remarks>
/// <param name="filepath">The path to the CSV file containing candlestick data. The file must exist and be accessible.</param>
/// <returns>A list of smart candlestick objects parsed from the CSV file. The list will be empty if the file contains no data
/// rows.</returns>
        public List<aSmartCandlestick> ReadSmartCandlesticksFromCSV(string filepath)
        {
            var smartCandlesticks = new List<aSmartCandlestick>();
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine();//skip header
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var smartCandlestick = new aSmartCandlestick(line);
                    smartCandlesticks.Add(smartCandlestick);
                }
            }
            return smartCandlesticks;
        }

/// <summary>
/// Converts a list of aCandlestick objects to a list of aSmartCandlestick objects.
/// </summary>
/// <param name="candlesticks">The list of aCandlestick instances to convert. Cannot be null.</param>
/// <returns>A list of aSmartCandlestick objects created from the input candlesticks. The list will be empty if the input list is
/// empty.</returns>
        public List<aSmartCandlestick> ConvertList(List<aCandlestick> candlesticks)
        {
            var smartCandlesticks = new List<aSmartCandlestick>();
            foreach (var candlestick in candlesticks)
            {
                var smartCandlestick = new aSmartCandlestick(candlestick);
                smartCandlesticks.Add(smartCandlestick);
            }
            return smartCandlesticks;
        }
    }
}