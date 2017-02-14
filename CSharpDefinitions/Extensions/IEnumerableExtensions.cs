using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Extensions {

    internal static class IEnumerableExtensions {

        public static IEnumerable<T> Concat<T>(this IEnumerable<T>  first, T item) {
            var second = new T[] { item };

            return first == null ? second : first.Concat(second);
        }

    }

}
