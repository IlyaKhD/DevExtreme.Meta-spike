using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc {

    public class Processor {

        public IEnumerable<ClassMeta> GetMeta(params string[] fileNames) {
            var jsdoc = new JSDocCommand().Run(fileNames.Select(f => $"samples/{f}"));
            return ParseOutput(jsdoc.Output);
        }

        static IEnumerable<ClassMeta> ParseOutput(string json) {
            var output = JsonConvert.DeserializeObject<JSDocEntry[]>(json);

            var meta = new Hierarchy<JSDocEntry>();
            foreach(var docEntry in output) {
                if(docEntry.Mixed) // ignore resolved mixins
                    continue;

                meta.Add(docEntry.Longname, docEntry, docEntry.Memberof, docEntry.Mixes);
            }

            return meta.Entries.Values
                .Where(e => e.Value.Kind == "class")
                .Select(c =>
                    new ClassMeta(
                        c.Value.Longname,
                        c.NestedEntries.Select(GetPropMeta).OrderBy(p => p.Name)
                    )
                );
        }

        static PropertyMeta GetPropMeta(Hierarchy<JSDocEntry>.Entry entry) {
            var nestedProps = entry.NestedEntries.Select(GetPropMeta);
            var types = entry.Value.Type.Names?.Select(GetTypeName);
            var defaultValue = GetDefaultValue(entry.Value.Defaultvalue, types?.First());

            return new PropertyMeta(entry.Value.Name, defaultValue, types, nestedProps);
        }

        static object GetDefaultValue(string rawDefaultValue, string defaultType) {
            if(String.IsNullOrEmpty(rawDefaultValue))
                return null;

            switch(defaultType) {
                case "number":
                    int value;
                    Int32.TryParse(rawDefaultValue, out value);
                    return value;

                default:
                    return rawDefaultValue;
            }
        }

        static string GetTypeName(string type) {
            if(type.Equals("int", StringComparison.OrdinalIgnoreCase))
                return "number";

            return type;
        }

        struct JSDocEntry {
            public readonly string Kind;
            public readonly string Name;
            public readonly bool Mixed;
            // class attrs
            public readonly string[] Mixes;
            // prop attrs
            public readonly string Longname;
            public readonly string Memberof;
            public readonly string Defaultvalue;
            public readonly JSDocType Type;

            [JsonConstructor]
            public JSDocEntry(
                string kind,
                string name,
                string[] mixes,
                string longname,
                string memberof,
                string defaultvalue,
                bool mixed,
                JSDocType type
            ) {
                Kind = kind;
                Name = name;
                Mixes = mixes;
                Longname = longname;
                Memberof = memberof;
                Defaultvalue = defaultvalue;
                Type = type;
                Mixed = mixed;
            }

            public struct JSDocType {
                public string[] Names;

                [JsonConstructor]
                public JSDocType(string[] name) {
                    Names = name;
                }
            }
        }
    }

}
