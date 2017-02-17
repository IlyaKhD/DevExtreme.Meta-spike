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
                        ""name"": ""classA"",
                        ""props"": 
                        [
                            {
                                ""name"": ""prop1"",
                                ""types"": [ ""number"", ""string"" ],
                                ""default"": ""abc""
                            }
                        ]
                    }
                ]
            ";
        #endregion

        [Test]
        public void GenericProp_CSHarpDefinitions() {
            var processor = new CSharpDefinitions.Processor();
            var actual = processor.GetMeta(new[] { typeof(CSharpSample.ClassA) });

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }

        [Test]
        public void GenericProp_JSDoc() {
            var processor = new JSDoc.Processor();
            var actual = processor.GetMeta("GenericProp.js");

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }
    }

}
