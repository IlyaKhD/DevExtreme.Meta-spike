using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.AxisSettings {

    public interface dxChartOptions {

        ChartCommonAxisSettings commonAxisSettings { get; }
    }

    public interface dxPolarChartOptions {

        PolarCommonAxisSettings commonAxisSettings { get; }
    }

    public interface ChartAxis : ChartCommonAxisSettings, Axis { }

    public interface PolarAxis : PolarCommonAxisSettings, Axis { }

    public interface ChartCommonAxisSettings {

        ChartAxisLabel label { get; }
    }

    public interface PolarCommonAxisSettings {

        PolarAxisLabel label { get; }
    }

    [InjectedType]
    public interface ChartAxisLabel : CommonAxisLabelSettings {

        string alignment { get; }
    }

    [InjectedType]
    public interface PolarAxisLabel : CommonAxisLabelSettings {

        [DefaultValue("enlargeTickInterval")]
        string overlappingBehavior { get; }
    }

    [InjectedType]
    public interface Axis {

        [DefaultValue(10)]
        int logarithmBase { get; }
    }

    [InjectedType]
    public interface CommonAxisLabelSettings {

        [DefaultValue(5)]
        int indentFromAxis { get; }
    }
}