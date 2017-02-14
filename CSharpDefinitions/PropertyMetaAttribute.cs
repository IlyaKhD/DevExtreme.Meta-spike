using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    [AttributeUsage(AttributeTargets.Property)]
    class PropertyMetaAttribute : Attribute {
        public readonly string Name;
        public readonly object DefaultValue;

        public PropertyMetaAttribute(string name, object defaultValue) {
            Name = name;
            DefaultValue = defaultValue;
        }
    }

}
