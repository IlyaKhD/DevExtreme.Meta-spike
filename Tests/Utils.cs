using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tests {

    static class Utils {

        public static string NormalizeJson(string jsonString) {
            return
                Regex.Replace (
                    Regex.Replace(jsonString, @"\s+", " "),
                    @"(?<=:) | (?=:)| (?={)|(?<={) | (?=})|(?<=}) |(?<=,) | (?=,) | (?=\[)|(?<=\[) | (?=\])|(?<=\])", String.Empty
                )
                .Trim(' ');
        }
    }

}
