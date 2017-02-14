using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples {

    public class GenericProp {

        public string GetMeta() => new Processor().GetMeta(
            new[] { typeof(ClassA) }
        );

        class ClassA {

            public GenericValue<int, string> Prop1 => new GenericValue<int, string>("abc");
        }
    }

}
