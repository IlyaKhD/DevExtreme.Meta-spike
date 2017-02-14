using NUnit.Framework;
using System;

namespace Tests {

    [TestFixture]
    public class CSharpDefinitionsTests {

        [Test]
        public void ProvidesPropertyMap() {
            #region expected
            var expected =
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

            var sample = new CSharpDefinitions.Samples.PropertyMap();

            Assert.AreEqual(Utils.NormalizeJson(expected), Utils.NormalizeJson(sample.GetMeta()));
        }

        [Test]
        public void ProvidesGenericProp() {
            #region expected
            var expected = @"
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

            var sample = new CSharpDefinitions.Samples.GenericProp();

            Assert.AreEqual(Utils.NormalizeJson(expected), Utils.NormalizeJson(sample.GetMeta()));
        }
    }

}
