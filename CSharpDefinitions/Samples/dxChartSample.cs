using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.dxChartSample {

    public class dxChart {

        public CommonSeriesSettings commonSeriesSettings => null;
        public GenericValue<BarSeries, LineSeries, GenericValue<BarSeries, LineSeries>[]> series => null;

        public class CommonSeriesSettings : SeriesSettings.cornerRadius, SeriesSettings.valueField, SeriesSettings.width {

            public string type => "line";
            public LineSeriesSettings line => null;
            public BarSeriesSettings bar => null;

            public int cornerRadius => Any.INT;
            public string valueField => Any.STRING;
            public int width => Any.INT;
        }
    }

    public class LineSeries : LineSeriesSettings {

        public string type => "line";
        public string name => null;
    }

    public class BarSeries : BarSeriesSettings {

        public string type => "bar";
        public string name => null;
    }

    public class LineSeriesSettings : SeriesSettings.valueField, SeriesSettings.width {

        public string valueField => Any.STRING;
        public int width => Any.INT;
    }

    public class BarSeriesSettings : SeriesSettings.cornerRadius, SeriesSettings.valueField {

        public int cornerRadius => Any.INT;
        public string valueField => Any.STRING;
    }

    namespace SeriesSettings {

        interface valueField {

            [PropertyValue("val")]
            string valueField { get; }
        }

        interface width {
            
            [PropertyValue(2)]
            int width { get; }
        }

        interface cornerRadius {

            [PropertyValue(0)]
            int cornerRadius { get; }
        }
    }

    static class Any {
        public const int INT = Int32.MaxValue;
        public const string STRING = "";
    }

}
