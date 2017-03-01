using CSharpDefinitions.Samples.AxisSettings_Hidden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.AxisSettings {

    public class dxChartOptions {
        public ChartCommonAxisSettings commonAxisSettings => null;
    }

    public class dxPolarChartOptions {
        public PolarCommonAxisSettings commonAxisSettings => null;
    }

    public class ChartAxis : ChartCommonAxisSettings, Mixes<Axis> { }

    public class PolarAxis : PolarCommonAxisSettings, Mixes<Axis> { }

    public class ChartCommonAxisSettings {

        public Label label => null;

        public class Label : CommonAxisLabelSettings {

            public string alignment => null;
        }
    }

    public class PolarCommonAxisSettings {

        public Label label => null;

        public class Label : CommonAxisLabelSettings {

            public string overlappingBehavior => "enlargeTickInterval";
        }
    }

}

namespace CSharpDefinitions.Samples.AxisSettings_Hidden {

    public class Axis {

        public int logarithmBase => 10;
    }

    public class CommonAxisLabelSettings : IMixin {

        public int indentFromAxis => 5;
    }
}