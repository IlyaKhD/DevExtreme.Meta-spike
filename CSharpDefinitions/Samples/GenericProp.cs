using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.GenericProp {

    public class font {

        public GenericValue<int, string> Size => new GenericValue<int, string>(14);
    }

}
