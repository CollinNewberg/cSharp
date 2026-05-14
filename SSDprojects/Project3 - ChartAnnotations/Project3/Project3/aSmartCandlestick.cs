using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    /// <summary>
    /// Provides additional computed properties for candlestick data, such as body and range values, to facilitate
    /// advanced financial analysis.
    /// </summary>
    /// <remarks>This class extends the base aCandlestick type by exposing commonly used candlestick metrics,
    /// including body range, upper and lower shadows, and total range. These properties are useful for technical
    /// analysis scenarios where detailed candlestick characteristics are required.</remarks>
    public class aSmartCandlestick : aCandlestick
    {
        public decimal Range { get; private set; }
        public decimal bodyTop { get; private set; }
        public decimal bodyBottom { get; private set; }
        public decimal bodyRange { get; private set; }
        public decimal upperRange { get; private set; }
        public decimal lowerRange { get; private set; }
        public bool isBullish { get; private set; }
        public bool isBearish { get; private set; }
        private void computeRanges()
        {
            Range = high - low;
            bodyTop = Math.Max(open, close);
            bodyBottom = Math.Min(close, open);
            bodyRange = bodyTop - bodyBottom;
            upperRange = high - bodyTop;
            lowerRange = bodyBottom - low;
            isBullish = close > open;
            isBearish = open > close;

        }



        /// <summary>
        /// Initializes a new instance of the aSmartCandlestick class using the specified string representation.
        /// </summary>
        /// <param name="s">The string representation used to initialize the candlestick instance. Cannot be null.</param>
        public aSmartCandlestick(string s) : base(s) 
        {
            computeRanges();
        }
        
         
        /// <summary>
        /// Initializes a new instance of the aSmartCandlestick class.
        /// </summary>
        public aSmartCandlestick() 
        {
            computeRanges();
        }


        /// <summary>
        /// Initializes a new instance of the aSmartCandlestick class with the specified date, price values, and trading
        /// volume.
        /// </summary>
        /// <param name="date">The date and time that the candlestick represents.</param>
        /// <param name="open">The opening price for the specified date.</param>
        /// <param name="high">The highest price reached during the specified date.</param>
        /// <param name="low">The lowest price reached during the specified date.</param>
        /// <param name="close">The closing price for the specified date.</param>
        /// <param name="volume">The total trading volume for the specified date.</param>
        public aSmartCandlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, ulong volume) : base(date, open, high, low, close, volume) 
        {
            computeRanges();
        }


        /// <summary>
        /// Initializes a new instance of the aSmartCandlestick class using the specified source candlestick.
        /// </summary>
        /// <param name="sourceCandlestick">The candlestick instance whose values are used to initialize the new aSmartCandlestick. Cannot be null.</param>
        public aSmartCandlestick(aCandlestick sourceCandlestick) : base(sourceCandlestick) 
        {
            computeRanges();
        }


        /// <summary>
        /// Initializes a new instance of the aSmartCandlestick class by copying the values from an existing
        /// aSmartCandlestick instance.
        /// </summary>
        /// <param name="sourceSmartCandlestick">The aSmartCandlestick instance to copy values from. Cannot be null.</param>
        public aSmartCandlestick(aSmartCandlestick sourceSmartCandlestick) : base(sourceSmartCandlestick) 
        {
            Range = sourceSmartCandlestick.Range;
            bodyTop = sourceSmartCandlestick.bodyTop;
            bodyBottom = sourceSmartCandlestick.bodyBottom;
            bodyRange = sourceSmartCandlestick.bodyRange;
            upperRange = sourceSmartCandlestick.upperRange;
            isBullish = sourceSmartCandlestick.isBullish;
            isBearish = sourceSmartCandlestick.isBearish;
        }



    }
}
