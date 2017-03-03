using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.GenericProp {

    public class font {

        public Union<int, string> Size => new Union<int, string>(14);
    }

}
