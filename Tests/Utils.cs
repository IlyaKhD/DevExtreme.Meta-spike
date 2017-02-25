using Common;
using Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;

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

        public static string Serialize(IEnumerable<ClassMeta> input, params Expression<Func<PropertyMeta, object>>[] allowedPropMetaAttrs) {
            return JsonConvert.SerializeObject(
                input,
                new JsonSerializerSettings { ContractResolver = new TestsContractResolver(allowedPropMetaAttrs) }
            );
        }

        class TestsContractResolver : DefaultContractResolver {

            readonly Expression<Func<PropertyMeta, object>>[] _allowedPropMetaAttrs;

            public TestsContractResolver(Expression<Func<PropertyMeta, object>>[] allowedPropMetaAttrs) {
                _allowedPropMetaAttrs = allowedPropMetaAttrs;
            }

            protected override List<MemberInfo> GetSerializableMembers(Type objectType) {
                var result = base.GetSerializableMembers(objectType);

                var propMetaType = typeof(PropertyMeta);
                if(objectType != propMetaType)
                    return result;

                return result.Where(IsNotIgnored).ToList();
            }

            bool IsNotIgnored(MemberInfo member) {
                if(member.MemberType != MemberTypes.Property && member.MemberType != MemberTypes.Field)
                    return true;

                if(_allowedPropMetaAttrs?.Length < 1)
                    return true;

                return _allowedPropMetaAttrs.Any(p => GetMemberInfo<PropertyMeta>(p) == member);
            }

            static MemberInfo GetMemberInfo<T>(Expression<Func<T, object>> expr) {
                var target = expr.Body;
                if(expr.Body.NodeType == ExpressionType.Convert)
                    target = ((UnaryExpression)target).Operand;

                var memberExpr = target as MemberExpression;
                if(memberExpr == null)
                    return null;

                return memberExpr.Member;
            }

            protected override string ResolvePropertyName(string propertyName) => base.ResolvePropertyName(propertyName.ToLowerCamelCase());
        }
    }

}
