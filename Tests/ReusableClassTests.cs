using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpSample = CSharpDefinitions.Samples.ReusableClass;

namespace Tests {

    public class ReusableClassTests {


        #region Epected
        const string EXPECTED = @"
            [
                {
                    ""name"": ""label"",
                    ""props"": 
                    [
                        {
                            ""name"": ""font"",
                            ""types"": [ ""viz.font"" ],
                            ""default"": null
                        }
                    ]
                },
                {
                    ""name"": ""viz.font"",
                    ""props"": 
                    [
                        {
                            ""name"": ""color"",
                            ""types"": [ ""string"" ],
                            ""default"": ""#FFFFFF""
                        },
                        {
                            ""name"": ""family"",
                            ""types"": [ ""string"" ],
                            ""default"": ""'Segoe UI', 'Helvetica Neue', 'Trebuchet MS', Verdana""
                        },
                        {
                            ""name"": ""weight"",
                            ""types"": [ ""number"" ],
                            ""default"": 400
                        }
                    ]
                }
            ]
        ";
        #endregion

        [Test]
        public void ReusableClass_CSHarpDefinitions() {
            var processor = new CSharpDefinitions.Processor(typeof(CSharpSample.label).Namespace);
            var meta = processor.GetMeta(new[] { typeof(CSharpSample.label), typeof(CSharpSample.viz.font) });

            var actual = new Serializer(meta)
                .SelectProps<PropertyMeta>(p => p.Name, p => p.Types, p => p.Default)
                .SelectProps<ClassMeta>(c => c.Name, c => c.Props)
                .Serialize();

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.NormalizeJson(actual));
        }

        [Test]
        public void ReusableClass_JSDoc() {
            var processor = new JSDoc.Processor();
            var meta = processor.GetMeta("ReusableClass.js");

            var actual = new Serializer(meta)
                .SelectProps<PropertyMeta>(p => p.Name, p => p.Types, p => p.Default)
                .SelectProps<ClassMeta>(c => c.Name, c => c.Props)
                .Serialize();

            Assert.AreEqual(Utils.NormalizeJson(EXPECTED), Utils.NormalizeJson(actual));
        }
    }

}
