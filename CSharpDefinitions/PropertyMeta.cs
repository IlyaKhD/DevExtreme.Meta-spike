using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    struct PropertyMeta {
        public readonly string Name;
        public readonly object Default;

        public PropertyMeta(string name, object defaultValue) {
            Name = name;
            Default = defaultValue;
        }
    }

}
