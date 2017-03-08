using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsDeclarations;

namespace Tests.TsDeclarations {

    public class GeneratorTests {


        [Test]
        public void TS_Generates_vizCharts() {
            #region expected

            // TODO: add functions:
            //      BaseSeries:
            // isSelected(): boolean;
            // getColor(): string;
            // getPointByPos(positionIndex: number): Object;
            // getAllPoints(): Array<BasePoint>;
            // show(): void;
            //      BasePoint
            // getLabel(): any;

            var expected = @"
                declare module DevExpress.viz.charts {

                    export interface BaseSeries {

                        fullState: number;
                        name: string;
                    }

                    export interface BasePoint {

                        fullState: number;
                        originalArgument: any;
                        series: BaseSeries;
                    }
                }
            ";
            #endregion

            #region test data
            var classes = new[] {
                new ClassMeta(
                    "BaseSeries",
                    new [] {
                        new PropertyMeta("fullState", new [] { "number" }),
                        new PropertyMeta("name", new [] { "string" })
                    },
                    parentType: null
                ),
                new ClassMeta(
                    "BasePoint",
                    new [] {
                        new PropertyMeta("fullState", new [] { "number" }),
                        new PropertyMeta("originalArgument", new [] { "any" }),
                        new PropertyMeta("series", new [] { "BaseSeries" }),
                    },
                    parentType: null
                )
            };
            #endregion

            var actual = new Generator().Generate("DevExpress.viz.charts", classes);

            Assert.AreEqual(Utils.NormalizeJson(expected), Utils.NormalizeJson(actual));
        }
    }

}
