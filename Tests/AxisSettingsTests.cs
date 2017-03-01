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
                            ""default"": null
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
                            ""default"": null
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
                            ""default"": 10
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
                            ""default"": 10
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
                                    ""default"": null
                                },
                                {
                                    ""name"": ""indentFromAxis"",
                                    ""types"": [ ""number"" ],
                                    ""default"": 5
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
                                    ""name"": ""overlappingBehavior"",
                                    ""types"": [ ""string"" ],
                                    ""default"": ""enlargeTickInterval""
                                },
                                {
                                    ""name"": ""indentFromAxis"",
                                    ""types"": [ ""number"" ],
                                    ""default"": 5
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
