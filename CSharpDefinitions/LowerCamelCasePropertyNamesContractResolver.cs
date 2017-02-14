using CSharpDefinitions.Extensions;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    internal class LowerCamelCasePropertyNamesContractResolver : DefaultContractResolver {

        protected override string ResolvePropertyName(string propertyName) => base.ResolvePropertyName(propertyName.ToLowerCamelCase());
    }

}
