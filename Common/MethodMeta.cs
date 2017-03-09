using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {

    public struct MethodMeta {
        public readonly string Name;
        public readonly string ReturnType;
        public readonly PropertyMeta[] Args;

        public MethodMeta(
            string name,
            string returnType,
            IEnumerable<PropertyMeta> args = null
        ) {
            Name = name;
            ReturnType = returnType;
            Args = args?.ToArray();
            if(Args?.Length < 1)
                Args = null;
        }

        public static IEqualityComparer<MethodMeta> Comparer = new EqualityComparerComparer();

        class EqualityComparerComparer : IEqualityComparer<MethodMeta> {

            public bool Equals(MethodMeta x, MethodMeta y) => x.Name.Equals(y.Name);

            public int GetHashCode(MethodMeta obj) => obj.Name.GetHashCode();
        }
    }

}
