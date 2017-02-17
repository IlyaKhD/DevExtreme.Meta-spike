using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.GenericProp {

    public class ClassA {

        public GenericValue<int, string> Prop1 => new GenericValue<int, string>("abc");
    }

}
