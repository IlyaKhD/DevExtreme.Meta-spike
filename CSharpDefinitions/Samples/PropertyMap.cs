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

        class ClassA : Prop1, Prop3 {

            public int Prop1 => Any.INT;
            public string Prop3 => Any.STRING;
        }

        class ClassB : Prop1, Prop2 {

            public int Prop1 => Any.INT;
            public string Prop2 => Any.STRING;
        }

        class ClassC : Prop2 {

            public string Prop4 => "xyz";
            public string Prop2 => Any.STRING;
        }

        #region CommonProps definitions

        interface Prop1 {

            [PropertyValue(123)]
            int Prop1 { get; }
        }

        interface Prop2 {

            [PropertyValue("abc")]
            string Prop2 { get; }
        }

        interface Prop3 {

            [PropertyValue("def")]
            string Prop3 { get; }
        }

        #endregion

        static class Any {
            public const int INT = Int32.MaxValue;
            public const string STRING = "";
        }

    }

}
