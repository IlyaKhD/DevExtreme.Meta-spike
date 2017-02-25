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
                        ""name"": ""candleStickSeries"",
                        ""props"":
                        [
                            {
                                ""name"": ""innerColor"",
                                ""types"": [ ""string"" ],
                                ""default"": ""#ffffff""
                            },
                            {
                                ""name"": ""openValueField"",
                                ""types"": [ ""string"" ],
                                ""default"": ""open""
                            },
                            {
                                ""name"": ""reduction"",
                                ""types"": [ ""object"" ],
                                ""default"": null
                            }
                        ]
                    },
                    {
                        ""name"": ""stockSeries"",
                        ""props"":
                        [
                            {
                                ""name"": ""hoverMode"",
                                ""types"": [ ""string"" ],
                                ""default"": ""onlyPoint""
                            },
                            {
                                ""name"": ""openValueField"",
                                ""types"": [ ""string"" ],
                                ""default"": ""open""
                            },
                            {
                                ""name"": ""reduction"",
                                ""types"": [ ""object"" ],
                                ""default"": null
                            }
                        ]
                    },
                    {
                        ""name"": ""barSeries"",
                        ""props"":
                        [
                            {
                                ""name"": ""cornerRadius"",
                                ""types"": [ ""number"" ],
                                ""default"": 0
                            },
                            {
                                ""name"": ""minBarSize"",
                                ""types"": [ ""number"" ],
                                ""default"": 0
                            }
                        ]
                    }
                ]
            ";
        #endregion

        [Test]
        public void PropertyMap_CSHarpDefinitions() {
            var processor = new CSharpDefinitions.Processor(typeof(CSharpSample.stockSeries).Namespace);
            var meta = processor.GetMeta(new[] { typeof(CSharpSample.candleStickSeries), typeof(CSharpSample.stockSeries), typeof(CSharpSample.barSeries) });

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.Serialize(meta, p => p.Name, p => p.Types, p => p.Default));
        }

        [Test]
        public void PropertyMap_JSDoc() {
            var processor = new JSDoc.Processor();
            var meta = processor.GetMeta("PropertyMap.js");

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.Serialize(meta, p => p.Name, p => p.Types, p => p.Default));
        }
    }

}
