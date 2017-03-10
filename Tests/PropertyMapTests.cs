using Common;
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
                        ""name"": ""CandleStickSeries"",
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
                        ""name"": ""StockSeries"",
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
                        ""name"": ""BarSeries"",
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
            var processor = new CSharpDefinitions.Processor(typeof(CSharpSample.StockSeries).Namespace);
            var meta = processor.GetMeta(new[] { typeof(CSharpSample.CandleStickSeries), typeof(CSharpSample.StockSeries), typeof(CSharpSample.BarSeries) });

            var actual = new Serializer(meta)
                .SelectProps<PropertyMeta>(p => p.Name, p => p.Types, p => p.Default)
                .SelectProps<ClassMeta>(c => c.Name, c => c.Props)
                .Serialize();

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }

        [Test]
        public void PropertyMap_JSDoc() {
            var processor = new JSDoc.Processor();
            var meta = processor.GetMeta("PropertyMap.js");

            var actual = new Serializer(meta)
                .SelectProps<PropertyMeta>(p => p.Name, p => p.Types, p => p.Default)
                .SelectProps<ClassMeta>(c => c.Name, c => c.Props)
                .Serialize();

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }
    }

}
