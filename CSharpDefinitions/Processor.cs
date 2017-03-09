using Common;
using Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            return types.Select(
                t => new ClassMeta(
                    GetTypeName(t),
                    GetClassProps(t).OrderBy(p => p.Name),
                    GetClassMethods(t).OrderBy(p => p.Name),
                    parentType: GetRelTypeName(GetParents(t).FirstOrDefault())
                )
            );
        }

        IEnumerable<PropertyMeta> GetClassProps(Type type)
        {
            foreach(var parent in GetParents(type))
            {
                if(!IsInlineType(parent))
                    continue;
               
                foreach(var parentProp in GetClassProps(parent))
                    yield return parentProp;
            }

            foreach(var prop in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
                yield return CreatePropMeta(prop);
        }

        IEnumerable<MethodMeta> GetClassMethods(Type type)
        {
            foreach(var parent in GetParents(type))
            {   
                foreach(var parentMethod in GetClassMethods(parent))
                    yield return parentMethod;
            }

            foreach(var method in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).Where(t => !t.IsSpecialName))
                yield return CreateMethodMeta(method);
        }

        PropertyMeta CreatePropMeta(PropertyInfo prop) {
            var defaultValue = prop.GetCustomAttribute<DefaultValueAttribute>()?.Value;
            var propType = prop.PropertyType;

            return CreateMemberMeta(prop.Name.ToLowerCamelCase(), propType, defaultValue);
        }


        MethodMeta CreateMethodMeta(MethodInfo method)
        {
            var returnType = method.ReturnType;

            var aliasedType = GetAliasedType(returnType);
            if(aliasedType != null) {
                returnType = aliasedType;
            }          

            return new MethodMeta(
                method.Name.ToLowerCamelCase(),
                GetTypeName(returnType),
                GetParameters(method.GetParameters())
            );
        }

        IEnumerable<PropertyMeta> GetParameters(ParameterInfo[] parameters)
        {
            foreach(var parameter in parameters)
                yield return CreateParameterMeta(parameter);
        }

        PropertyMeta CreateParameterMeta(ParameterInfo param)
        {
            var defaultValue = param.GetCustomAttribute<DefaultValueAttribute>()?.Value;
            var propType = param.ParameterType;

            return CreateMemberMeta(param.Name.ToLowerCamelCase(), propType, defaultValue);
        }

        PropertyMeta CreateMemberMeta(string name, Type type, object defaultValue)
        {
            var aliasedType = GetAliasedType(type);
            if(aliasedType != null) {
                defaultValue = defaultValue ?? type.GetCustomAttribute<DefaultValueAttribute>()?.Value;
                type = aliasedType;
            }

            if(defaultValue is Union)
                defaultValue = ((Union)defaultValue).Value;

            IEnumerable<PropertyMeta> nestedProps = null;

            if(IsInlineType(type)) {
                nestedProps = GetClassProps(type).OrderBy(p => p.Name).ToArray();
                type = typeof(object);
            }

            return new PropertyMeta(
                name,
                GetPropTypes(type).OrderBy(t => t),
                defaultValue,
                props: nestedProps
            );
        }


        IEnumerable<string> GetPropTypes(Type propType) {
            if((propType.GetInterface(nameof(ICollection))) != null) {
                var arrayMebersTypes = propType.GetGenericArguments().SelectMany(GetPropTypes);
                yield return $"array<{String.Join("|", arrayMebersTypes)}>";

                yield break;
            }

            if(typeof(Union).IsAssignableFrom(propType)) {
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
            if(type?.FullName?.StartsWith(_rootNamespace + ".") == true)
                return type.FullName.Substring(_rootNamespace.Length + 1);

            return null;
        }

        static IEnumerable<Type> GetParents(Type type) {
            var allInterfaces = type.GetInterfaces();
            return allInterfaces.Except(allInterfaces.SelectMany(i => i.GetInterfaces()));
        }

        static Type GetAliasedType(Type type) {
            return type
                .GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(Alias<>))
                ?.GetGenericArguments()
                ?.FirstOrDefault();
        }

        static bool IsInlineType(Type type) => type?.GetCustomAttribute<InjectedTypeAttribute>() != null;

    }

}
