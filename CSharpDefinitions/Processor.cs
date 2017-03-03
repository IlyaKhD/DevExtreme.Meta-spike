using Common;
using Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
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
            return types.Select(t => new ClassMeta(GetTypeName(t), GetClassProps(t).OrderBy(p => p.Name), parentType: GetRelTypeName(t.BaseType)));
        }

        IEnumerable<PropertyMeta> GetClassProps(Type type) {
            var multiBase = type.GetInterfaces().FirstOrDefault(i => typeof(Mixes).IsAssignableFrom(i));
            if(multiBase != null) {
                foreach(var parentProp in multiBase.GetGenericArguments().SelectMany(GetClassProps))
                    yield return parentProp;
            };

            if(typeof(IMixin).IsAssignableFrom(type.BaseType)) {
                foreach(var parentProp in GetClassProps(type.BaseType))
                    yield return parentProp;
            }

            var instance = Activator.CreateInstance(type);

            foreach(var prop in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
                yield return CreatePropMeta(prop, prop.GetValue(instance));
        }

        PropertyMeta CreatePropMeta(PropertyInfo prop, object propValue) {
            var defaultValue = propValue is IUnion ? ((IUnion)propValue).Value : propValue;
            var propType = prop.PropertyType;
            IEnumerable<PropertyMeta> nestedProps = null;

            if(propType.IsNested) {
                nestedProps = GetClassProps(propType).OrderBy(p => p.Name);
                propType = typeof(object);
            }

            return new PropertyMeta(
                prop.Name.ToLowerCamelCase(),
                defaultValue,
                GetPropTypes(propType).OrderBy(t => t),
                props: nestedProps
            );
        }

        IEnumerable<string> GetPropTypes(Type propType) {
            if((propType.GetInterface(nameof(ICollection))) != null) {
                var arrayMebersTypes = propType.GetGenericArguments().SelectMany(GetPropTypes);
                yield return $"array<{String.Join("|", arrayMebersTypes)}>";

                yield break;
            }

            if(typeof(IUnion).IsAssignableFrom(propType)) {
                foreach(var nestedPropType in propType.GetGenericArguments()) {
                    foreach(var type in GetPropTypes(nestedPropType))
                        yield return type;
                }

                yield break;
            }

            yield return GetTypeName(propType);
        }

        string GetTypeName(Type type) {

            if(type == typeof(string))
                return "string";

            if(type == typeof(int))
                return "number";

            if(type == typeof(object))
                return "object";

            return GetRelTypeName(type) ?? type.FullName;
        }

        string GetRelTypeName(Type type) {
            if(type.FullName.StartsWith(_rootNamespace + "."))
                return type.FullName.Substring(_rootNamespace.Length + 1);

            return null;
        }

    }

}
