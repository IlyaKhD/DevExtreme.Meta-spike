using Common;
using Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    public class Processor {

        readonly string _rootNamespace;

        public Processor(string rootNamespace) {
            _rootNamespace = rootNamespace;
        }

        public IEnumerable<ClassMeta> GetMeta(IEnumerable<Type> types) {
            return types.Select(t => new ClassMeta(GetTypeName(t), GetClassProps(t)));
        }

        IEnumerable<PropertyMeta> GetClassProps(Type type) {
            var instance = Activator.CreateInstance(type);

            var interfaceProps = type.GetInterfaces()
                .SelectMany(i => i.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
                .Select(p => CreatePropMeta(p, p.GetCustomAttribute<PropertyValueAttribute>()?.Value));

            var ownProps = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Select(p => CreatePropMeta(p, p.GetValue(instance)))
                .Except(interfaceProps, PropertyMeta.Comparer);

            return ownProps.Concat(interfaceProps);
        }

        PropertyMeta CreatePropMeta(PropertyInfo prop, object propValue) {
            var defaultValue = propValue is IGenericValue ? ((IGenericValue)propValue).Value : propValue;

            return new PropertyMeta(
                prop.Name.ToLowerCamelCase(),
                defaultValue,
                GetPropTypes(prop),
                props: null
            );
        }

        IEnumerable<string> GetPropTypes(PropertyInfo prop) {
            var propType = prop.PropertyType;

            if(!typeof(IGenericValue).IsAssignableFrom(propType)) {
                yield return GetTypeName(propType);
                yield break;
            }

            foreach(var type in propType.GetGenericArguments())
                yield return GetTypeName(type);
        }

        string GetTypeName(Type type) {

            if(type == typeof(string))
                return "string";

            if(type == typeof(int))
                return "number";

            if(type == typeof(object))
                return "object";

            if(type.FullName.StartsWith(_rootNamespace + "."))
                return type.FullName.Substring(_rootNamespace.Length + 1);

            return type.FullName;
        }
    }

}
