using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    [AttributeUsage(AttributeTargets.Property)]
    class PropertyValueAttribute : Attribute {
        public readonly object Value;

        public PropertyValueAttribute(object value) {
            Value = value;
        }
    }

}
