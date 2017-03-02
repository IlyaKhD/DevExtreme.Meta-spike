using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.ReusableClass {

    public interface label {

        viz.font Font { get; }
    }

    namespace viz {

        public interface font {

            [DefaultValue("#FFFFFF")]
            string Color { get; }

            [DefaultValue("'Segoe UI', 'Helvetica Neue', 'Trebuchet MS', Verdana")]
            string Family { get; }

            [DefaultValue(400)]
            int Weight { get; }
        }
    }

}
