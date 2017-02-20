using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc {

    public class Processor {

        public string GetMeta(params string[] fileNames) {
            var jsdoc = new JSDocCommand().Run(fileNames.Select(f => $"samples/{f}"));
            var result = ParseOutput(jsdoc.Output);

            return JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings { ContractResolver = new LowerCamelCasePropertyNamesContractResolver() }
            );
        }

        static IEnumerable<ClassMeta> ParseOutput(string json) {
            var output = JsonConvert.DeserializeObject<JSDocEntry[]>(json);

            var mixinProps = output
                .Where(e => e.Kind == "mixin")
                .ToArray()
                .SelectMany(m => output.Where(e => e.Memberof == m.Name))
                .ToDictionary(
                    p => p.Longname,
                    p => GetPropMeta(p)
                );

            var props = new Dictionary<string, ICollection<PropertyMeta>>();
            foreach(var propDoc in output.Where(e => e.Kind == "member")) {
                if(String.IsNullOrEmpty(propDoc.Memberof))
                    continue;

                if(propDoc.Mixed) // ignore resolved mixins
                    continue;

                if(!props.ContainsKey(propDoc.Memberof))
                    props[propDoc.Memberof] = new List<PropertyMeta>();

                props[propDoc.Memberof].Add(GetPropMeta(propDoc));
            }

            return output
                .Where(e => e.Kind == "class")
                .Select(c =>
                    new ClassMeta(
                        c.Name,
                        (props.ContainsKey(c.Name) ? props[c.Name] : Enumerable.Empty<PropertyMeta>())
                            .OrderBy(p => p.Name)
                            .Concat(
                                (c.Mixes?.Where(m => mixinProps.ContainsKey(m))?.Select(m => mixinProps[m]) ?? Enumerable.Empty<PropertyMeta>())
                                .OrderBy(p => p.Name)
                            )
                    )
                );
        }

        static PropertyMeta GetPropMeta(JSDocEntry propDoc) {
            var types = propDoc.Type.Names?.Select(GetTypeName);

            if(String.IsNullOrEmpty(propDoc.Defaultvalue))
                return new PropertyMeta(propDoc.Name, propDoc.Defaultvalue, types);

#warning must die
            if(types.Contains("string"))
                return new PropertyMeta(propDoc.Name, propDoc.Defaultvalue, types);

            object defaultValue = null;
            switch(types.First()) {
                case "number":
                    int value;
                    Int32.TryParse(propDoc.Defaultvalue, out value);
                    defaultValue = value;
                    break;

                default:
                    defaultValue = propDoc.Defaultvalue;
                    break;
            }

            return new PropertyMeta(propDoc.Name, defaultValue, types);
        }

        static string GetTypeName(string type) {
            if(type.Equals("int", StringComparison.OrdinalIgnoreCase))
                return "number";

            if(type.Equals("string", StringComparison.OrdinalIgnoreCase))
                return "string";

            if(type.Equals("object", StringComparison.OrdinalIgnoreCase))
                return "object";

            throw new Exception($"Unknown type: '{type}'");
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
