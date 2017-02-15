using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var sample = new CSharpDefinitions.Samples.GenericProp();

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.NormalizeJson(sample.GetMeta()));
        }

        [Test]
        public void GenericProp_JSDoc() {
            var sample = new JSDoc.Samples.GenericProp();

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.NormalizeJson(sample.GetMeta()));
        }
    }

}
