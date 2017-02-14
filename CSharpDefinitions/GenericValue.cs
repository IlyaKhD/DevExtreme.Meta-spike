using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions {

    internal interface IGenericValue { }

    internal abstract class GenericValue<T1, T2> : IGenericValue { }

}
