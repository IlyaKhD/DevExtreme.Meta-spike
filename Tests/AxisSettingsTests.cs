using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {

    public class AxisSettingsTests {

        #region Expected
        const string EXPECTED = @"
            [
                {
                    ""name"": ""PolarAxis"",
                    ""props"":
                    [
                        {
                            ""name"": ""logarithmBase"",
                            ""types"": [ ""number"" ],
                            ""default"": 10
                        },
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
                },
                {
                    ""name"": ""ChartAxis"",
                    ""props"":
                    [
                        {
                            ""name"": ""logarithmBase"",
                            ""types"": [ ""number"" ],
                            ""default"": 10
                        },
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
                }
            ]
        ";
        #endregion
    }

}
