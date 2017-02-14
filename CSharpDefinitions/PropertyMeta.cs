using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    internal struct PropertyMeta {
        public readonly string Name;
        public readonly string[] Types;
        public readonly object Default;

        public PropertyMeta(string name, object defaultValue, IEnumerable<string> types) {
            Name = name;
            Default = defaultValue;
            Types = types?.ToArray();
        }

        public static IEqualityComparer<PropertyMeta> Comparer = new EqualityComparerComparer();

        class EqualityComparerComparer : IEqualityComparer<PropertyMeta> {

            public bool Equals(PropertyMeta x, PropertyMeta y) => x.Name.Equals(y.Name);

            public int GetHashCode(PropertyMeta obj) => obj.Name.GetHashCode();
        }
    }

}
