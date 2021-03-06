﻿module.exports = function () {
    /**
     * @class CandleStickSeries
     * @mixes commonProps.innerColor
     * @mixes commonProps.reduction
     * @mixes commonProps.openValueField
     */
    return {
    };
};

module.exports = function () {
    /**
     * @class StockSeries
     * @mixes commonProps.reduction
     * @mixes commonProps.openValueField
     */
    return {

        /**
         * @property
         * @memberof StockSeries
         * @type {string}
         * @default onlyPoint
         */

        hoverMode: "onlyPoint"
    };
};

module.exports = function () {
    /**
     * @class BarSeries
     * @mixes commonProps.cornerRadius
     * @mixes commonProps.minBarSize
     */
    return {
    };
};

/**
 * @name commonProps
 * @mixin
 */
new {

    /**
     * @memberof commonProps
     * @type {int}
     * @default 0
     */
    cornerRadius: 0,

    /**
     * @memberof commonProps
     * @type {int}
     * @default 0
     */
    minBarSize: 0,

    /**
     * @memberof commonProps
     * @type {string}
     * @default #ffffff
     */
    innerColor: "#ffffff",

    /**
     * @memberof commonProps
     * @type {string}
     * @default open
     */
    openValueField: 'open',

    /**
     * @memberof commonProps
     * @type {object}
     */
    reduction: {
        /**
          * @memberof commonProps.reduction
          */
        color: "#000000",

        /**
          * @memberof commonProps.reduction
          */
        level: "close"
    }

}