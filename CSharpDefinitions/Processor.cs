using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions
{

    public class Processor
    {
        const BindingFlags PROPS_BINDING = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;

        public string GetMeta(IEnumerable<Type> types)
        {
            var result = new List<ClassMeta>();

            foreach (var type in types)
            {
                var metaAttr = type.GetCustomAttribute<ClassMetaAttribute>();
                if (metaAttr == null)
                    continue;

                result.Add(new ClassMeta(metaAttr.Name, GetClassProps(type)));
            }

            return JsonConvert.SerializeObject
            (
                result,
                new JsonSerializerSettings { ContractResolver = new LowerCamelCasePropertyNamesContractResolver() }
            );
        }

        static IEnumerable<PropertyMeta> GetClassProps(Type type)
        {
            var interfaceProps = type.GetInterfaces().SelectMany(i => i.GetProperties(PROPS_BINDING));
            var ownProps = type.GetProperties(PROPS_BINDING);

            return ownProps
                .Concat(interfaceProps)
                .Select(p => p.GetCustomAttribute<PropertyMetaAttribute>())
                .Where(p => p != null)
                .Select(p => p.Meta);
        }
    }

}
