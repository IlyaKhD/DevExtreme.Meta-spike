using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Extensions {

    internal static class StringExtensions {

        public static string ToLowerCamelCase(this string value) {
            return value?.Length > 1 ? value.Substring(0, 1).ToLower() + value.Substring(1) : value;
        }
    }

}
