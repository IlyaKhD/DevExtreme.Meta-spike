using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    public interface Union {
        object Value { get; }
    }

    public interface Union<T1, T2> : Union { }

    public interface Union<T1, T2, T3> : Union { }


}
