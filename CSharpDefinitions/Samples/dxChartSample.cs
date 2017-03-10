using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.dxChartSample {

    public interface dxChart {

        CommonSeriesSettings commonSeriesSettings { get; }
        Union<BarSeries, LineSeries, Union<BarSeries, LineSeries>[]> series { get; }
        dxChart instance();
    }

    [InjectedType]
    public interface CommonSeriesSettings {

        [DefaultValue("line")]
        string type { get; }
        LineSeriesSettings line { get; }
        BarSeriesSettings bar { get; }

        SeriesSettings.valueField valueField { get; set; }
        SeriesSettings.cornerRadius cornerRadius { get; set; }
        SeriesSettings.width width { get; set; }
    }


    public interface LineSeries : LineSeriesSettings {

        [DefaultValue("line")]
        string type { get; }
        string name { get; }
    }

    public interface BarSeries : BarSeriesSettings {

        [DefaultValue("bar")]
        string type { get; }
        string name { get; }
    }

    public interface LineSeriesSettings {

        SeriesSettings.valueField valueField { get; set; }
        SeriesSettings.width width { get; set; }
    }

    public interface BarSeriesSettings {

        SeriesSettings.cornerRadius cornerRadius { get; }
        SeriesSettings.valueField valueField { get; }
    }

    namespace SeriesSettings {

        [DefaultValue("val")]
        public class valueField : Alias<string> { }

        [DefaultValue(2)]
        public class width : Alias<int> { }

        [DefaultValue(0)]
        public class cornerRadius : Alias<int> { }

    }
}