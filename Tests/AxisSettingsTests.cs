using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpSample = CSharpDefinitions.Samples.AxisSettings;

namespace Tests {

    public class AxisSettingsTests {

        #region Expected
        const string EXPECTED = @"
            [
                {
                    ""name"": ""dxChartOptions"",
                    ""props"": 
                    [
                        {
                            ""name"": ""commonAxisSettings"",
                            ""types"": [ ""ChartCommonAxisSettings"" ],
                            ""default"": null,
                            ""props"": null
                        }
                    ],
                    ""parentType"": null
                },
                {
                    ""name"": ""dxPolarChartOptions"",
                    ""props"": 
                    [
                        {
                            ""name"": ""commonAxisSettings"",
                            ""types"": [ ""PolarCommonAxisSettings"" ],
                            ""default"": null,
                            ""props"": null
                        }
                    ],
                    ""parentType"": null
                },
                {
                    ""name"": ""ChartAxis"",
                    ""props"":
                    [
                        {
                            ""name"": ""logarithmBase"",
                            ""types"": [ ""number"" ],
                            ""default"": 10,
                            ""props"": null
                        }
                    ],
                    ""parentType"": ""ChartCommonAxisSettings""
                },
                {
                    ""name"": ""PolarAxis"",
                    ""props"":
                    [
                        {
                            ""name"": ""logarithmBase"",
                            ""types"": [ ""number"" ],
                            ""default"": 10,
                            ""props"": null
                        }
                    ],
                    ""parentType"": ""PolarCommonAxisSettings""
                },
                {
                    ""name"": ""ChartCommonAxisSettings"",
                    ""props"": 
                    [
                        {
                            ""name"": ""label"",
                            ""types"": [ ""object"" ],
                            ""default"": null,
                            ""props"": 
                            [
                                {
                                    ""name"": ""alignment"",
                                    ""types"": [ ""string"" ],
                                    ""default"": null,
                                    ""props"": null
                                },
                                {
                                    ""name"": ""indentFromAxis"",
                                    ""types"": [ ""number"" ],
                                    ""default"": 5,
                                    ""props"": null
                                }
                            ]
                        }
                    ],
                    ""parentType"": null
                },
                {
                    ""name"": ""PolarCommonAxisSettings"",
                    ""props"": 
                    [
                        {
                            ""name"": ""label"",
                            ""types"": [ ""object"" ],
                            ""default"": null,
                            ""props"": 
                            [
                                {
                                    ""name"": ""indentFromAxis"",
                                    ""types"": [ ""number"" ],
                                    ""default"": 5,
                                    ""props"": null
                                },
                                {
                                    ""name"": ""overlappingBehavior"",
                                    ""types"": [ ""string"" ],
                                    ""default"": ""enlargeTickInterval"",
                                    ""props"": null
                                }
                            ]
                        }
                    ],
                    ""parentType"": null
                }
            ]
        ";
        #endregion

    }

}
