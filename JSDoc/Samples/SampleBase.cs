using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc.Samples {

    public abstract class SampleBase {

        protected string GetMeta(params string[] fileNames) {
            var jsdoc = new JSDocCommand().Run(fileNames.Select(f => $"samples/{f}"));
            var result = new JSDocHelper().ParseOutput(jsdoc.Output);

            return JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings { ContractResolver = new LowerCamelCasePropertyNamesContractResolver() }
            );
        }
    }

}
