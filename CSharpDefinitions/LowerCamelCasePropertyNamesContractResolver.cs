using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions
{

    internal class LowerCamelCasePropertyNamesContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            var actualPropertyName = propertyName.Length > 1
                ? propertyName.Substring(0, 1).ToLower() + propertyName.Substring(1)
                : propertyName;

            return base.ResolvePropertyName(actualPropertyName);
        }
    }

}
