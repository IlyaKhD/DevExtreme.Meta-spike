using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CSharpDefinitionsTests
    {

        [Test]
        public void ProvidesPropertyMap()
        {
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
                                ""default"": 123
                            },
                            {
                                ""name"": ""prop3"",
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
                                ""default"": 123
                            },
                            {
                                ""name"": ""prop2"",
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
                                ""default"": ""xyz""
                            },
                            {
                                ""name"": ""prop2"",
                                ""default"": ""abc""
                            }
                        ]
                    }
                ]
            ";
            #endregion

            var sample = new CSharpDefinitions.PropertyMap.Sample();

            Assert.AreEqual(Utils.NormalizeJson(expected), Utils.NormalizeJson(sample.GetMeta()));
        }
    }

}
