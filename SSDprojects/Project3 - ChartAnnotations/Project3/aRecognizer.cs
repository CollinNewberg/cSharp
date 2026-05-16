using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{

    //In class Dr. Jeanty told us that using virtual classes/methods were going to break and to use abstract classes/methods instead as abstract classes are not instantiated (aRecognizer is NOT to be instantiated)


    /// <summary>
    /// Provides an abstract base class for recognizing specific candlestick patterns within a sequence of candlestick data.
    /// </summary>
    /// <remarks>Derived classes implement pattern-specific logic by overriding the required members. This class
    /// enables scanning a list of candlesticks to identify all occurrences of a defined pattern, returning the starting
    /// indices of each match. Thread safety is not guaranteed; callers should ensure appropriate synchronization if used
    /// concurrently.</remarks>
    abstract public class aRecognizer
    {
        // Number of candlesticks required for this pattern
        protected abstract int patternLength { get; }

        //Pattern name for identification (optional, can be used for logging or display purposes)
        public abstract string patternName { get; }

        // Pattern-specific matching logic (implemented in derived classes)
        protected abstract bool match(List<aSmartCandlestick> testedLOSC);

        // Scan through the full list and return matches
        public List<int> recognize(List<aSmartCandlestick> LOSC)
        {
            List<int> matchIndices = new List<int>();

            if (LOSC == null || LOSC.Count < patternLength)
                return matchIndices;

            for (int i = patternLength - 1; i < LOSC.Count; i++)
            {
                var window = LOSC.GetRange(i - (patternLength - 1), patternLength);
                if (match(window))
                {
                    matchIndices.Add(i);
                }
            }

            return matchIndices;
        }
    }

    /// <summary>
    /// Provides functionality to identify Marubozu candlestick patterns within a sequence of candlestick data.
    /// </summary>
    /// <remarks>Range = BodyRange</remarks>
    public class marubozuRecognizer : aRecognizer
    {

        protected override int patternLength => 1;

        public override string patternName => "Marubozu";

        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            //Told IN CLASS to not have an error range 
            var c = testedLOSC[0];

            if (c.bodyRange == 0) return false;


            return c.bodyRange == c.Range;
        }
    }

    /// <summary>
    /// Provides functionality to recognize the Bullish Marubozu candlestick pattern within a sequence of candlesticks.
    /// </summary>
    /// <remarks>The Bullish Marubozu pattern is identified when a candlestick is bullish and its body
    /// occupies the entire range, indicating strong buying pressure. This recognizer analyzes a single candlestick at a
    /// time to determine if it matches the pattern.</remarks>
    public class bullishMarubozuRecognizer : aRecognizer
    {
        protected override int patternLength => 1;

        public override string patternName => "Bullish Marubozu";

        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            var c = testedLOSC[0];

            if (!c.isBullish)
                return false;

            return c.bodyRange == c.Range;
        }
    }
    /// <summary>
    /// Provides functionality to identify bearish Marubozu candlestick patterns within a sequence of candlesticks.
    /// </summary>
    /// <remarks>A bearish Marubozu is a candlestick pattern characterized by a long bearish body with little
    /// to no upper or lower shadows. This recognizer can be used in technical analysis scenarios to detect potential
    /// bearish signals in financial market data.</remarks>
    public class bearishMarubozuRecognizer : aRecognizer
    {
        protected override int patternLength => 1;

        public override string patternName => "Bearish Marubozu";
        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            var c = testedLOSC[0];

            if (!c.isBearish)
                return false;

            return c.bodyRange == c.Range;
        }
    }
    /// <summary>
    /// Identifies bullish or bearish engulfing candlestick patterns within a sequence of candlesticks.
    /// </summary>
    /// <remarks>An engulfing pattern occurs when a candlestick fully engulfs the previous one, indicating a
    /// potential reversal in market trend. This recognizer supports both bullish and bearish engulfing patterns. Use
    /// this class as part of a candlestick pattern recognition system to detect possible trend reversals in financial
    /// time series data.</remarks>
    public class engulfingRecognizer : aRecognizer
    {
        protected override int patternLength => 2;

        public override string patternName => "Engulfing";

        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            //"newer" is newer candlestick, "older" is older candlestick, will pass newer candlestick to the annotation
            var newer = testedLOSC[1];
            var older = testedLOSC[0];

            // Bullish engulfing
            bool bullish = older.isBearish && newer.isBullish && newer.bodyTop > older.bodyTop && newer.bodyBottom < older.bodyBottom;

            // Bearish engulfing
            bool bearish = older.isBullish && newer.isBearish && newer.bodyTop > older.bodyTop && newer.bodyBottom < older.bodyBottom;

            return bullish || bearish;
        }
    }

    /// <summary>
    /// Identifies the presence of a bullish engulfing candlestick pattern within a sequence of candlesticks.
    /// </summary>
    /// <remarks>A bullish engulfing pattern is a two-candle reversal pattern that may indicate a potential bullish
    /// trend. This recognizer analyzes two consecutive candlesticks and determines if the second candlestick fully engulfs
    /// the body of the first, with the first being bearish and the second being bullish. Use this class to detect bullish
    /// reversal signals in candlestick data.</remarks>
    public class bullishEngulfingRecognizer : aRecognizer
    {
        protected override int patternLength => 2;

        public override string patternName => "Bullish Engulfing";

        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            var newer = testedLOSC[1];
            var older = testedLOSC[0];

            if (!older.isBearish || !newer.isBullish)
                return false;

            return older.isBearish && newer.isBullish && newer.bodyTop > older.bodyTop && newer.bodyBottom < older.bodyBottom;
        }
    }
    /// <summary>
    /// Identifies the Bearish Engulfing candlestick pattern within a sequence of candlesticks.
    /// </summary>
    /// <remarks>The Bearish Engulfing pattern is a two-candle reversal pattern commonly used in technical
    /// analysis to signal a potential bearish reversal. This recognizer analyzes a sequence of candlesticks and
    /// determines if the pattern is present based on standard criteria. Use this class as part of a candlestick pattern
    /// recognition system to detect bearish reversal signals.</remarks>
    public class bearishEngulfingRecognizer : aRecognizer
    {
        protected override int patternLength => 2;

        public override string patternName => "Bearish Engulfing";

        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            var newer = testedLOSC[1];
            var older = testedLOSC[0];

            if (!older.isBullish || !newer.isBearish)
                return false;

            return older.isBullish && newer.isBearish && newer.bodyTop > older.bodyTop && newer.bodyBottom < older.bodyBottom;
        }
    }

    //Harami
    public class haramiRecognizer : aRecognizer
    {
        protected override int patternLength => 2;

        public override string patternName => "Harami";

        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            //"newer" is newer candlestick, "older" is older candlestick, will pass newer candlestick to the annotation
            var newer = testedLOSC[1];
            var older = testedLOSC[0];

            // Bullish harami
            bool bullish = older.isBearish && newer.isBullish && older.bodyTop > newer.bodyTop && older.bodyBottom < newer.bodyBottom;

            // Bearish harami
            bool bearish = older.isBullish && newer.isBearish && older.bodyTop > newer.bodyTop && older.bodyBottom < newer.bodyBottom;

            return bullish || bearish;
        }
    }

    public class dojiRecognizer : aRecognizer
    {
        protected override int patternLength => 1;
        public override string patternName => "Doji";
        decimal bodyThreshold = 0.05m;
        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            var c = testedLOSC[0];
            // A Doji is typically defined as having a very small body, often with the open and close prices being equal or nearly equal.
            // Here we can define a threshold for what constitutes a "small" body. For simplicity, we'll check if the body range is zero.
            
            return c.bodyRange <= c.Range * bodyThreshold;
        }
    }
    /// <summary>
    /// a Dragonfly Doji recognier class
    /// </summary>
    public class dragonflyDojiRecognizer : aRecognizer
    {
        protected override int patternLength => 1;

        public override string patternName => "Dragonfly Doji";

        decimal bodyThreshold = 0.05m;
        decimal upperShadowThreshold = 1.05m;

        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            var c = testedLOSC[0];

            return c.bodyRange <= c.Range * bodyThreshold &&
                   c.upperRange <= c.high * upperShadowThreshold;
        }
    }
    //A gravestone doji recognize class
    public class gravestoneDojiRecognizer : aRecognizer
    {
        protected override int patternLength => 1;

        public override string patternName => "Gravestone Doji";

        decimal bodyThreshold = 0.05m;
        decimal lowerShadowThreshold = 0.05m;

        protected override bool match(List<aSmartCandlestick> testedLOSC)
        {
            var c = testedLOSC[0];

            decimal lowerRange = c.bodyBottom - c.low;

            return c.bodyRange <= c.Range * bodyThreshold &&
                   lowerRange <= c.Range * lowerShadowThreshold;
        }
    }
}