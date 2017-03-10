using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpSample = CSharpDefinitions.Samples.GenericProp;

namespace Tests {

    public class GenericPropTests {

        #region expected
        const string EXPECTED = @"
                [
                    {
                        ""name"": ""font"",
                        ""props"": 
                        [
                            {
                                ""name"": ""size"",
                                ""types"": [ ""number"", ""string"" ],
                                ""default"": 14
                            }
                        ]
                    }
                ]
            ";
        #endregion

        [Test]
        public void GenericProp_CSHarpDefinitions() {
            var processor = new CSharpDefinitions.Processor(typeof(CSharpSample.font).Namespace);
            var meta = processor.GetMeta(new[] { typeof(CSharpSample.font) });

            var actual = new Serializer(meta)
                .SelectProps<PropertyMeta>(p => p.Name, p => p.Types, p => p.Default)
                .SelectProps<ClassMeta>(c => c.Name, c => c.Props)
                .Serialize();

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }

        [Test]
        public void GenericProp_JSDoc() {
            var processor = new JSDoc.Processor();
            var meta = processor.GetMeta("GenericProp.js");

            var actual = new Serializer(meta)
                .SelectProps<PropertyMeta>(p => p.Name, p => p.Types, p => p.Default)
                .SelectProps<ClassMeta>(c => c.Name, c => c.Props)
                .Serialize();

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }
    }

}
