using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples {

    public class PropertyMap {

        public string GetMeta() => new Processor().GetMeta(
            new[] {
                typeof(ClassA),
                typeof(ClassB),
                typeof(ClassC)
            }
        );

#warning currently iherited props return stub values just to be short and compilable. May be we could use these values for meta needs (e.g. default value)

        [ClassMeta("classA")]
        class ClassA : Prop1, Prop3 {

            public int Prop1 => Any.INT;
            public string Prop3 => Any.STRING;
        }

        [ClassMeta("classB")]
        class ClassB : Prop1, Prop2 {

            public int Prop1 => Any.INT;
            public string Prop2 => Any.STRING;
        }

        [ClassMeta("classC")]
        class ClassC : Prop2 {

            [PropertyMeta("prop4", defaultValue: "xyz")]
            public string Prop4 => Any.STRING;
            public string Prop2 => Any.STRING;
        }

        #region CommonProps definitions

        interface Prop1 {

            [PropertyMeta("prop1", defaultValue: 123)]
            int Prop1 { get; }
        }

        interface Prop2 {

            [PropertyMeta("prop2", defaultValue: "abc")]
            string Prop2 { get; }
        }

        interface Prop3 {

            [PropertyMeta("prop3", defaultValue: "def")]
            string Prop3 { get; }
        }

        #endregion

        static class Any {
            public const int INT = Int32.MaxValue;
            public const string STRING = "";
        }

    }

}
