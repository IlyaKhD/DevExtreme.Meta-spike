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

            var expected = @"
                declare module DevExpress.viz.charts {

                    export interface BaseSeries {

                        fullState: number;
                        name: string;
                        isSelected(): boolean;
                        getColor(): string;
                        getPointByPos(positionIndex: number): Object;
                        getAllPoints(): Array<BasePoint>;
                        show(): void;
                    }

                    export interface BasePoint {

                        fullState: number;
                        originalArgument: any;
                        series: BaseSeries;
                        getLabel(): any;
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
                    new [] {
                        new MethodMeta("isSelected", "boolean"),
                        new MethodMeta("getColor", "string"),
                        new MethodMeta("getPointByPos", "Object", new [] { new PropertyMeta("positionIndex", new [] { "number" }) }),
                        new MethodMeta("getAllPoints", "Array<BasePoint>"),
                        new MethodMeta("show", "void")
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
                    new [] {
                        new MethodMeta("getLabel", "any")
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
