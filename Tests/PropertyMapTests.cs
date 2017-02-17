using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpSample = CSharpDefinitions.Samples.PropertyMap;

namespace Tests {

    public class PropertyMapTests {
        #region expected
        const string EXPECTED =
        @"
                [
                    {
                        ""name"": ""classA"",
                        ""props"":
                        [
                            {
                                ""name"": ""prop1"",
                                ""types"": [ ""number"" ],
                                ""default"": 123
                            },
                            {
                                ""name"": ""prop3"",
                                ""types"": [ ""string"" ],
                                ""default"": ""def""
                            }
                        ]
                    },
                    {
                        ""name"": ""classB"",
                        ""props"":
                        [
                            {
                                ""name"": ""prop1"",
                                ""types"": [ ""number"" ],
                                ""default"": 123
                            },
                            {
                                ""name"": ""prop2"",
                                ""types"": [ ""string"" ],
                                ""default"": ""abc""
                            }
                        ]
                    },
                    {
                        ""name"": ""classC"",
                        ""props"":
                        [
                            {
                                ""name"": ""prop4"",
                                ""types"": [ ""string"" ],
                                ""default"": ""xyz""
                            },
                            {
                                ""name"": ""prop2"",
                                ""types"": [ ""string"" ],
                                ""default"": ""abc""
                            }
                        ]
                    }
                ]
            ";
        #endregion

        [Test]
        public void PropertyMap_CSHarpDefinitions() {
            var processor = new CSharpDefinitions.Processor();
            var actual = processor.GetMeta(new[] { typeof(CSharpSample.ClassA), typeof(CSharpSample.ClassB), typeof(CSharpSample.ClassC) });

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }

        [Test]
        public void PropertyMap_JSDoc() {
            var processor = new JSDoc.Processor();
            var actual = processor.GetMeta("PropertyMap.js", "PropertyMap-A.js", "PropertyMap-B.js", "PropertyMap-C.js");

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }
    }

}
