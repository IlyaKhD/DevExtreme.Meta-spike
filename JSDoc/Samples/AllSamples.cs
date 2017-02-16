using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc.Samples {

    public class GenericProp : SampleBase {

        public string GetMeta() => GetMeta("GenericProp.js");
    }

    public class PropertyMap : SampleBase {
        public string GetMeta() => GetMeta("PropertyMap.js", "PropertyMap-A.js", "PropertyMap-B.js", "PropertyMap-C.js");
    }
}
