using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpSample = CSharpDefinitions.Samples.ReusableClass;

namespace Tests {

    public class ReusableClassTests {


        #region Epected
        const string EXPECTED = @"
            [
                {
                    ""name"": ""label"",
                    ""props"": 
                    [
                        {
                            ""name"": ""font"",
                            ""types"": [ ""viz.font"" ],
                            ""default"": null
                        }
                    ]
                },
                {
                    ""name"": ""viz.font"",
                    ""props"": 
                    [
                        {
                            ""name"": ""color"",
                            ""types"": [ ""string"" ],
                            ""default"": ""#FFFFFF""
                        },
                        {
                            ""name"": ""family"",
                            ""types"": [ ""string"" ],
                            ""default"": ""'Segoe UI', 'Helvetica Neue', 'Trebuchet MS', Verdana""
                        },
                        {
                            ""name"": ""weight"",
                            ""types"": [ ""number"" ],
                            ""default"": 400
                        }
                    ]
                }
            ]
        ";
        #endregion

        [Test]
        public void ReusableClass_CSHarpDefinitions() {
            var processor = new CSharpDefinitions.Processor(typeof(CSharpSample.label).Namespace);
            var actual = processor.GetMeta(new[] { typeof(CSharpSample.label), typeof(CSharpSample.viz.font) });

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.NormalizeJson(actual));
        }

        [Test]
        public void ReusableClass_JSDoc() {
            var processor = new JSDoc.Processor();
            var actual = processor.GetMeta("ReusableClass.js");

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.NormalizeJson(actual));
        }
    }

}
