using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpSample = CSharpDefinitions.Samples.dxChartSample;

namespace Tests {

    public class dxChartSampleTests {

        #region Expected
        const string EXPECTED = @"
            [
                {
                    ""name"": ""dxChart"",
                    ""props"": 
                    [
                        {
                            ""name"": ""commonSeriesSettings"",
                            ""types"": [ ""object"" ],
                            ""default"": null,
                            ""props"":
                            [
                                {
                                    ""name"": ""bar"",
                                    ""types"": [ ""BarSeriesSettings""],
                                    ""default"": null,
                                    ""props"": null
                                },
                                {
                                    ""name"": ""cornerRadius"",
                                    ""types"": [ ""number""],
                                    ""default"": 0,
                                    ""props"": null
                                },
                                {
                                    ""name"": ""line"",
                                    ""types"": [ ""LineSeriesSettings""],
                                    ""default"": null,
                                    ""props"": null
                                },
                                {
                                    ""name"": ""type"",
                                    ""types"": [ ""string""],
                                    ""default"": ""line"",
                                    ""props"": null
                                },
                                {
                                    ""name"": ""valueField"",
                                    ""types"": [ ""string""],
                                    ""default"": ""val"",
                                    ""props"": null
                                },
                                {
                                    ""name"": ""width"",
                                    ""types"": [ ""number""],
                                    ""default"": 2,
                                    ""props"": null
                                }
                            ]
                        },
                        {
                            ""name"": ""series"",
                            ""types"": [ ""array<BarSeries|LineSeries>"", ""BarSeries"", ""LineSeries""],
                            ""default"": null,
                            ""props"": null
                        }
                    ],
                    ""parentType"": null
                },
                {
                    ""name"": ""LineSeries"",
                    ""props"": 
                    [
                        {
                            ""name"": ""name"",
                            ""types"": [ ""string"" ],
                            ""default"": null,
                            ""props"": null
                        },
                        {
                            ""name"": ""type"",
                            ""types"": [ ""string"" ],
                            ""default"": ""line"",
                            ""props"": null
                        }
                    ],
                    ""parentType"": ""LineSeriesSettings""
                },
                {
                    ""name"": ""BarSeries"",
                    ""props"": 
                    [
                        {
                            ""name"": ""name"",
                            ""types"": [ ""string"" ],
                            ""default"": null,
                            ""props"": null
                        },
                        {
                            ""name"": ""type"",
                            ""types"": [ ""string"" ],
                            ""default"": ""bar"",
                            ""props"": null
                        }
                    ],
                    ""parentType"": ""BarSeriesSettings""
                },
                {
                    ""name"": ""LineSeriesSettings"",
                    ""props"": 
                    [
                        {
                            ""name"": ""valueField"",
                            ""types"": [ ""string"" ],
                            ""default"": ""val"",
                            ""props"": null
                        },
                        {
                            ""name"": ""width"",
                            ""types"": [ ""number"" ],
                            ""default"": 2,
                            ""props"": null
                        }
                    ],
                    ""parentType"": null
                },
                {
                    ""name"": ""BarSeriesSettings"",
                    ""props"": 
                    [
                        {
                            ""name"": ""cornerRadius"",
                            ""types"": [ ""number"" ],
                            ""default"": 0,
                            ""props"": null
                        },
                        {
                            ""name"": ""valueField"",
                            ""types"": [ ""string"" ],
                            ""default"": ""val"",
                            ""props"": null
                        }
                    ],
                    ""parentType"": null
                }
            ]
        ";
        #endregion

        [Test]
        public void dxChartSample_JSDoc() {
            var processor = new JSDoc.Processor();
            var meta = processor.GetMeta("dxChartSample.js");

            var actual = new Serializer(meta)
                .AllowOnly<PropertyMeta>(p => p.Name, p => p.Types, p => p.Default, p => p.Props)
                .AllowOnly<ClassMeta>(c => c.Name, c => c.Props, c => c.ParentType)
                .Serialize();
            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }

        [Test]
        public void dxChartSample_CSHarpDefinitions() {
            var processor = new CSharpDefinitions.Processor(typeof(CSharpSample.dxChart).Namespace);
            var meta = processor.GetMeta(new[] {
                typeof(CSharpSample.dxChart),
                typeof(CSharpSample.LineSeries),
                typeof(CSharpSample.BarSeries),
                typeof(CSharpSample.LineSeriesSettings),
                typeof(CSharpSample.BarSeriesSettings)
            });

            var actual = new Serializer(meta)
                .AllowOnly<PropertyMeta>(p => p.Name, p => p.Types, p => p.Default, p => p.Props)
                .AllowOnly<ClassMeta>(c => c.Name, c => c.Props, c => c.ParentType)
                .Serialize();
            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), actual);
        }
    }


}
