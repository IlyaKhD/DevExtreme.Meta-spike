using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.PropertyMap {

    public class CandleStickSeries : InnerColor, OpenValueField, Reduction {

        public string InnerColor => Any.STRING;
        public string OpenValueField => Any.STRING;
        public object Reduction => Any.STRING;
    }

    public class BarSeries : CornerRadius, MinBarSize {

        public int CornerRadius => Any.INT;
        public int MinBarSize => Any.INT;
    }

    public class StockSeries : OpenValueField, Reduction {

        public string HoverMode => "onlyPoint";
        public string OpenValueField => Any.STRING;
        public object Reduction => Any.STRING;
    }

    #region CommonProps definitions

    interface OpenValueField {

        [PropertyValue("open")]
        string OpenValueField { get; }
    }

    interface CornerRadius {

        [PropertyValue(0)]
        int CornerRadius { get; }
    }

    interface MinBarSize {

        [PropertyValue(0)]
        int MinBarSize { get; }
    }

    interface Reduction {

        object Reduction { get; }
    }

    interface InnerColor {

        [PropertyValue("#ffffff")]
        string InnerColor { get; }
    }

    #endregion

    static class Any {
        public const int INT = Int32.MaxValue;
        public const string STRING = "";
    }

}
