using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    [AttributeUsage(AttributeTargets.Class)]
    class ClassMetaAttribute : Attribute {
        public readonly string Name;

        public ClassMetaAttribute(string name) {
            Name = name;
        }

    }

}
