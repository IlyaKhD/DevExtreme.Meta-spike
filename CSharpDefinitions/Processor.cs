using CSharpDefinitions.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    public class Processor {
        const BindingFlags PROPS_BINDING = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;

        public string GetMeta(IEnumerable<Type> types) {
            var result = new List<ClassMeta>();

            foreach(var type in types) {
                var metaAttr = type.GetCustomAttribute<ClassMetaAttribute>();
                if(metaAttr == null)
                    continue;

                result.Add(new ClassMeta(metaAttr.Name, GetClassProps(type)));
            }

            return JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings { ContractResolver = new LowerCamelCasePropertyNamesContractResolver() }
            );
        }

        static IEnumerable<PropertyMeta> GetClassProps(Type type) {
            var interfaceProps = type.GetInterfaces().SelectMany(i => i.GetProperties(PROPS_BINDING));
            var ownProps = type.GetProperties(PROPS_BINDING);

            return ownProps
                .Concat(interfaceProps)
                .Where(p => Attribute.IsDefined(p, typeof(PropertyMetaAttribute)))
                .Select(p => CreatePropMeta(p));
        }

        static PropertyMeta CreatePropMeta(PropertyInfo prop) {
            var metaAttr = prop.GetCustomAttribute<PropertyMetaAttribute>();

            return new PropertyMeta(
                metaAttr.Name,
                metaAttr.DefaultValue,
                GetPropTypes(prop)
            );
        }

        static IEnumerable<string> GetPropTypes(PropertyInfo prop) {
            var propType = prop.PropertyType;

            if(!typeof(IGenericValue).IsAssignableFrom(propType)) {
                yield return GetTypeName(propType);
                yield break;
            }

            foreach(var type in propType.GetGenericArguments())
                yield return GetTypeName(type);
        }

        static string GetTypeName(Type type) {

            if(type == typeof(string))
                return "string";

            if(type == typeof(int))
                return "number";

            throw new Exception($"Unknown type: '{type.FullName}'");
        }
    }

}
