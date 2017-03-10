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
        readonly Dictionary<Type, List<MemberInfo>> _allowedMembers;

        public Serializer(object obj) {
            _obj = obj;
            _allowedMembers = new Dictionary<Type, List<MemberInfo>>();
        }

        public Serializer SelectProps<T>(params Expression<Func<T, object>>[] expr) {
            var type = typeof(T);
            if(!_allowedMembers.ContainsKey(type))
                _allowedMembers[type] = new List<MemberInfo>();

            _allowedMembers[type].AddRange(expr.Select(GetMemberInfo));
            return this;
        }

        public string Serialize() {
            return JsonConvert.SerializeObject(
                _obj,
                new JsonSerializerSettings {
                    ContractResolver = new TestsContractResolver(
                        _allowedMembers.ToDictionary(
                            m => m.Key,
                            m => m.Value as IReadOnlyCollection<MemberInfo>
                        )
                    )
                }
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

            readonly Dictionary<Type, IReadOnlyCollection<MemberInfo>> _allowedMemebers;

            public TestsContractResolver(IDictionary<Type, IReadOnlyCollection<MemberInfo>> allowedPropMetaAttrs) {
                _allowedMemebers = new Dictionary<Type, IReadOnlyCollection<MemberInfo>>(allowedPropMetaAttrs);
            }

            protected override List<MemberInfo> GetSerializableMembers(Type objectType) {
                var actualMembers = base.GetSerializableMembers(objectType);
                if(!_allowedMemebers.ContainsKey(objectType))
                    return actualMembers;

                return _allowedMemebers[objectType].Where(m => actualMembers.Contains(m)).ToList();
            }

            protected override string ResolvePropertyName(string propertyName) => base.ResolvePropertyName(propertyName.ToLowerCamelCase());
        }
    }

}
