using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDefinitions
{

    [AttributeUsage(AttributeTargets.Property)]
    class PropertyMetaAttribute : Attribute
    {
        public readonly PropertyMeta Meta;

        public PropertyMetaAttribute(string name, object defaultValue)
        {
            Meta = new PropertyMeta(name, defaultValue);
        }
    }

}
