/**
 * @class
 */
var dxChart = {

    /**
     * @memberof dxChart
     * @mixes seriesSettings
     * @type {object}
     */
    commonSeriesSettings: {

        /**
         * @memberof dxChart.commonSeriesSettings
         * @type {string}
         * @default line
         */
        type,

        /**
         * @memberof dxChart.commonSeriesSettings
         * @type {LineSeriesSettings}
         */
        line,

        /**
         * @memberof dxChart.commonSeriesSettings
         * @type {BarSeriesSettings}
         */
        bar
    },

    /**
     * @method
     * @memberof dxChart
     * @type dxChart
     * @returns {dxChart} returns instance
     */
    instance: function () {
        return "";
    },

    /**
     * @memberof dxChart
     * @type BarSeries|LineSeries|Array.<BarSeries|LineSeries>
     */
    series: [{}]
};

/**
 * @class
 * @extends LineSeriesSettings
 */
var LineSeries = {
    /**
     * @memberof LineSeries
     * @type {string}
     */
    name,

    /**
     * @memberof LineSeries
     * @type {string}
     * @default line
     */
    type
};

/**
 * @class
 * @extends BarSeriesSettings
 */
var BarSeries = {
    /**
     * @memberof BarSeries
     * @type {string}
     */
    name,

    /**
     * @memberof BarSeries
     * @type {string}
     * @default bar
     */
    type
};

/**
 * @class LineSeriesSettings
 * @mixes seriesSettings.valueField
 * @mixes seriesSettings.width
 */

/**
 * @class BarSeriesSettings
 * @mixes seriesSettings.valueField
 * @mixes seriesSettings.cornerRadius
 */

/**
 * @mixin
 */
var seriesSettings = {

    /**
     * @memberof seriesSettings
     * @type {string}
     * @default val
     */
    valueField,

    /**
     * @memberof seriesSettings
     * @type {int}
     * @default 2
     */
    width,

    /**
     * @memberof seriesSettings
     * @type {int}
     * @default 0
     */
    cornerRadius
};