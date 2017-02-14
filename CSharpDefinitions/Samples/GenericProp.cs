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

        [ClassMeta("classA")]
        class ClassA {

            [PropertyMeta("prop1", defaultValue: "abc")]
            public GenericValue<int, string> Prop1 => null;
        }
    }

}
