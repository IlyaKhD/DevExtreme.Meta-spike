using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.PropertyMap {

    public interface CandleStickSeries {

        SeriesSettings.InnerColor InnerColor { get; }
        SeriesSettings.OpenValueField OpenValueField { get; }
        SeriesSettings.Reduction Reduction { get; }
    }

    public interface BarSeries {

        SeriesSettings.CornerRadius CornerRadius { get; }
        SeriesSettings.MinBarSize MinBarSize { get; }
    }

    public interface StockSeries {

        [DefaultValue("onlyPoint")]
        string HoverMode { get; }

        SeriesSettings.OpenValueField OpenValueField { get; }
        SeriesSettings.Reduction Reduction { get; }
    }

    namespace SeriesSettings {

        [DefaultValue("open")]
        public class OpenValueField : Alias<string> { }

        [DefaultValue(0)]
        public class CornerRadius : Alias<int> { }

        [DefaultValue(0)]
        public class MinBarSize : Alias<int> { }

        public class Reduction : Alias<object> { }

        [DefaultValue("#ffffff")]
        public class InnerColor : Alias<string> { }
    }

}
