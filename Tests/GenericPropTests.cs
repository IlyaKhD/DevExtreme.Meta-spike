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

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.Serialize(meta, p => p.Name, p => p.Types, p => p.Default));
        }

        [Test]
        public void GenericProp_JSDoc() {
            var processor = new JSDoc.Processor();
            var meta = processor.GetMeta("GenericProp.js");

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.Serialize(meta, p => p.Name, p => p.Types, p => p.Default));
        }
    }

}
