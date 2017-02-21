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
            var processor = new CSharpDefinitions.Processor();
            var actual = processor.GetMeta(new[] { typeof(CSharpSample.CandleStickSeries), typeof(CSharpSample.StockSeries), typeof(CSharpSample.BarSeries) });

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }

        [Test]
        public void PropertyMap_JSDoc() {
            var processor = new JSDoc.Processor();
            var actual = processor.GetMeta("PropertyMap.js");

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }
    }

}
