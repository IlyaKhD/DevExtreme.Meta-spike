using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc {

    internal class JSDocHelper {

        public IEnumerable<ClassMeta> ParseOutput(string json) {
            var output = JsonConvert.DeserializeAnonymousType(
                json,
                new[] {
                    new {
                        // common
                        Kind = "",
                        Name = "",
                        // props
                        Memberof = "",
                        Defaultvalue = "",
                        Type = new {
                            names = new[] { "" }
                        }
                    }
                }
            );

            var props = new Dictionary<string, ICollection<PropertyMeta>>();
            foreach(var propDoc in output.Where(e => e.Kind == "member")) {
                if(!props.ContainsKey(propDoc.Memberof))
                    props[propDoc.Memberof] = new List<PropertyMeta>();

                props[propDoc.Memberof].Add(new PropertyMeta(propDoc.Name, propDoc.Defaultvalue, propDoc.Type.names.Select(GetTypeName)));
            }

            var result = output
                .Where(e => e.Kind == "class")
                .Select(c =>
                    new ClassMeta(
                        c.Name,
                        props.ContainsKey(c.Name) ? props[c.Name] : Enumerable.Empty<PropertyMeta>()
                    )
                );
            return result;
        }

        static string GetTypeName(string type) {
            if(type.Equals("int", StringComparison.OrdinalIgnoreCase))
                return "number";

            if(type.Equals("string", StringComparison.OrdinalIgnoreCase))
                return "string";

            throw new Exception($"Unknown type: '{type}'");
        }
    }

}
