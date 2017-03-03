using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    internal interface IUnion {
        object Value { get; }
    }

    public class Union<T1, T2> : IUnion {

        public object Value { get; private set; }

        public Union(T1 value) {
            Value = value;
        }

        public Union(T2 value) {
            Value = value;
        }
    }

    public class Union<T1, T2, T3> : IUnion {

        public object Value { get; private set; }

        public Union(T1 value) {
            Value = value;
        }

        public Union(T2 value) {
            Value = value;
        }

        public Union(T3 value) {
            Value = value;
        }
    }


}
