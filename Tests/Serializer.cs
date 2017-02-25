using Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests {

    internal class Serializer {

        readonly object _obj;
        readonly List<MemberInfo> _allowedPropMetaAttrs;

        public Serializer(object obj) {
            _obj = obj;
            _allowedPropMetaAttrs = new List<MemberInfo>();
        }

        public Serializer AllowOnly<T>(params Expression<Func<T, object>>[] expr) {
            _allowedPropMetaAttrs.AddRange(expr.Select(GetMemberInfo));
            return this;
        }

        public string Serialize() {
            return JsonConvert.SerializeObject(
                _obj,
                new JsonSerializerSettings { ContractResolver = new TestsContractResolver(_allowedPropMetaAttrs) }
            );
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

        class TestsContractResolver : DefaultContractResolver {

            readonly MemberInfo[] _allowedPropMetaAttrs;

            public TestsContractResolver(IEnumerable<MemberInfo> allowedPropMetaAttrs) {
                _allowedPropMetaAttrs = allowedPropMetaAttrs.ToArray();
            }

            protected override List<MemberInfo> GetSerializableMembers(Type objectType) {
                return base.GetSerializableMembers(objectType).Where(IsNotIgnored).ToList();
            }

            bool IsNotIgnored(MemberInfo member) {
                if(member.MemberType != MemberTypes.Property && member.MemberType != MemberTypes.Field)
                    return true;

                if(_allowedPropMetaAttrs?.Length < 1)
                    return true;

                return _allowedPropMetaAttrs.Contains(member);
            }

            protected override string ResolvePropertyName(string propertyName) => base.ResolvePropertyName(propertyName.ToLowerCamelCase());
        }
    }

}
