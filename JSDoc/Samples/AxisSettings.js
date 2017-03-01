/**
 * @class
 */
var dxChartOptions = {

    /**
     * @memberof dxChartOptions
     * @type {ChartCommonAxisSettings}
     */
    commonAxisSettings
};

/**
 * @class
 */
var dxPolarChartOptions = {

    /**
     * @memberof dxPolarChartOptions
     * @type {PolarCommonAxisSettings}
     */
    commonAxisSettings
};

/**
 * @class ChartAxis
 * @extends ChartCommonAxisSettings
 * @mixes Axis
 */

/**
 * @class PolarAxis
 * @extends PolarCommonAxisSettings
 * @mixes Axis
 */

/**
 * @mixin
 */
var Axis = {

    /**
     * @memberof Axis
     * @type {int}
     * @default 10
     */
    logarithmBase
};

/**
 * @class
 */
var ChartCommonAxisSettings = {

    /**
     * @memberof ChartCommonAxisSettings
     * @mixes Label
     * @type {object}
     */
    label: {
        /**
         * @memberof ChartCommonAxisSettings.label
         * @type {string}
         */
        alignment
    }
};

/**
 * @class
 */
var PolarCommonAxisSettings = {

    /**
     * @memberof PolarCommonAxisSettings
     * @mixes Label
     * @type {object}
     */
    label: {
        /**
         * @memberof PolarCommonAxisSettings.label
         * @type {string}
         * @default enlargeTickInterval
         */
        overlappingBehavior
    }
};

/**
 * @mixin
 */
var Label = {

    /**
     * @memberof Label
     * @type {int}
     * @default 5
     */
    indentFromAxis,
};