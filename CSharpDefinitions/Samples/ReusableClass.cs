using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.ReusableClass {

    public class label {

        public viz.font Font { get; }
    }

    namespace viz {

        public class font {

            public string Color => "#FFFFFF";
            public string Family => "'Segoe UI', 'Helvetica Neue', 'Trebuchet MS', Verdana";
            public int Weight => 400;
        }
    }

}
