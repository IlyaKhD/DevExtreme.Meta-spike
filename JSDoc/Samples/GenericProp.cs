using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc.Samples {

    public class GenericProp {

        public string GetMeta() {
            var jsdoc = new JSDocCommand().Run("samples/GenericProp.js");
            var result = new JSDocHelper().ParseOutput(jsdoc.Output);

            return JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings { ContractResolver = new LowerCamelCasePropertyNamesContractResolver() }
            );
        }
    }

}
