using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {

    public struct ClassMeta {
        public readonly string Name;
        public readonly PropertyMeta[] Props;
        public readonly string ParentType;

        public ClassMeta(string name, IEnumerable<PropertyMeta> props, string parentType) {
            Name = name;
            Props = props.ToArray();
            ParentType = parentType;
        }
    }

}
