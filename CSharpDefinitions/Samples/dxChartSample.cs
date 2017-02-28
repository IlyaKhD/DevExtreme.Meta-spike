using CSharpDefinitions.Samples.dxChartSampleHidden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.dxChartSample {

    public class dxChart {

        public CommonSeriesSettings commonSeriesSettings => null;
        public GenericValue<BarSeries, LineSeries, GenericValue<BarSeries, LineSeries>[]> series => null;

        public class CommonSeriesSettings : SeriesSettings {

            public string type => "line";
            public LineSeriesSettings line => null;
            public BarSeriesSettings bar => null;

            public new string valueField => base.valueField;
            public new int cornerRadius => base.cornerRadius;
            public new int width => base.width;
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

    public class LineSeriesSettings : SeriesSettings {

        public new string valueField => base.valueField;
        public new int width => base.width;
    }

    public class BarSeriesSettings : SeriesSettings {

        public new int cornerRadius => base.cornerRadius;
        public new string valueField => base.valueField;
    }

}

namespace CSharpDefinitions.Samples.dxChartSampleHidden {

    public class SeriesSettings {

        protected virtual string valueField => "val";
        protected virtual int width => 2;
        protected virtual int cornerRadius => 0;
    }
}