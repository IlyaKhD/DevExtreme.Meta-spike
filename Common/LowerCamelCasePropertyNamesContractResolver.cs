using Common.Extensions;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {

    public class LowerCamelCasePropertyNamesContractResolver : DefaultContractResolver {

        protected override string ResolvePropertyName(string propertyName) => base.ResolvePropertyName(propertyName.ToLowerCamelCase());
    }

}
