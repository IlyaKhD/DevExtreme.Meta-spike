using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    struct PropertyMeta {
        public readonly string Name;
        public readonly string[] Types;
        public readonly object Default;

        public PropertyMeta(string name, object defaultValue, IEnumerable<string> types) {
            Name = name;
            Default = defaultValue;
            Types = types?.ToArray();
        }
    }

}
