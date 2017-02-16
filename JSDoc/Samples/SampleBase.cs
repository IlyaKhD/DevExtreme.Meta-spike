using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc.Samples {

    public abstract class SampleBase {

        protected string GetMeta(string fileName) {
            var jsdoc = new JSDocCommand().Run($"samples/{fileName}");
            var result = new JSDocHelper().ParseOutput(jsdoc.Output);

            return JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings { ContractResolver = new LowerCamelCasePropertyNamesContractResolver() }
            );
        }
    }

}
