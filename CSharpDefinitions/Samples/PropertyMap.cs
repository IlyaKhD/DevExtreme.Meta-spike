using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.PropertyMap {

    public class CandleStickSeries : SeriesSettings {

        public new string InnerColor => base.InnerColor;
        public new string OpenValueField => base.OpenValueField;
        public new object Reduction => base.Reduction;
    }

    public class BarSeries : SeriesSettings {

        public new int CornerRadius => base.CornerRadius;
        public new int MinBarSize => base.MinBarSize;
    }

    public class StockSeries : SeriesSettings{

        public string HoverMode => "onlyPoint";

        public new string OpenValueField => base.OpenValueField;
        public new object Reduction => base.Reduction;
    }

    public class SeriesSettings {

        protected virtual string OpenValueField => "open";
        protected virtual int CornerRadius => 0;
        protected virtual int MinBarSize => 0;
        protected virtual object Reduction => null;
        protected virtual string InnerColor => "#ffffff";

    }

}
