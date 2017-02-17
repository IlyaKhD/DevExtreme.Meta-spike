using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    internal interface IGenericValue {
        object Value { get; }
    }

    public class GenericValue<T1, T2> : IGenericValue {

        public object Value { get; private set; }

        public GenericValue(T1 value) {
            Value = value;
        }

        public GenericValue(T2 value) {
            Value = value;
        }
    }

}
