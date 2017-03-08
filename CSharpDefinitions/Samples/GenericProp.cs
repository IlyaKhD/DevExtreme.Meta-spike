using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions.Samples.GenericProp {

    public interface font {

        [DefaultValue(14)]
        Union<int, string> Size { get; }
    }

}
