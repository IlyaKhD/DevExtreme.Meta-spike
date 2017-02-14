using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    struct ClassMeta {
        public readonly string Name;
        public readonly PropertyMeta[] Props;

        public ClassMeta(string name, IEnumerable<PropertyMeta> props) {
            Name = name;
            Props = props.ToArray();
        }
    }

}
