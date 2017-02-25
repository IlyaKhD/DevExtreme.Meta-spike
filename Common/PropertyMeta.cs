using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {

    public struct PropertyMeta {
        public readonly string Name;
        public readonly string[] Types;
        public readonly object Default;
        public readonly PropertyMeta[] Props;

        public PropertyMeta(
            string name,
            object defaultValue,
            IEnumerable<string> types,
            IEnumerable<PropertyMeta> props
        ) {
            Name = name;
            Default = defaultValue;
            Types = types?.ToArray();
            Props = props?.ToArray();
            if(Props?.Length < 1)
                Props = null;
        }

        public static IEqualityComparer<PropertyMeta> Comparer = new EqualityComparerComparer();

        class EqualityComparerComparer : IEqualityComparer<PropertyMeta> {

            public bool Equals(PropertyMeta x, PropertyMeta y) => x.Name.Equals(y.Name);

            public int GetHashCode(PropertyMeta obj) => obj.Name.GetHashCode();
        }
    }

}
