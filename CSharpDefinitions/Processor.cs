using Common;
using Common.Extensions;
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
        public const int NOVAL_INT = Int32.MaxValue;
        public const string NOVAL_STRING = "29ba8527a456401dafa26a108c6731a3";

        const BindingFlags PROPS_BINDING = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;

        public string GetMeta(IEnumerable<Type> types) {
            var result = types.Select(t => new ClassMeta(t.Name.ToLowerCamelCase(), GetClassProps(t)));

            return JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings { ContractResolver = new LowerCamelCasePropertyNamesContractResolver() }
            );
        }

        static IEnumerable<PropertyMeta> GetClassProps(Type type) {
            var instance = Activator.CreateInstance(type);

            var interfaceProps = type.GetInterfaces()
                .SelectMany(i => i.GetProperties(PROPS_BINDING))
                .Select(p => CreatePropMeta(p, p.GetCustomAttribute<PropertyValueAttribute>()?.Value));

            var ownProps = type.GetProperties(PROPS_BINDING)
                .Select(p => CreatePropMeta(p, p.GetValue(instance)))
                .Except(interfaceProps, PropertyMeta.Comparer);

            return ownProps.Concat(interfaceProps);
        }

        static PropertyMeta CreatePropMeta(PropertyInfo prop, object propValue) {
            var defaultValue = propValue is IGenericValue ? ((IGenericValue)propValue).Value : propValue;

            return new PropertyMeta(
                prop.Name.ToLowerCamelCase(),
                defaultValue,
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
