module.exports = function () {
    /**
     * @class stockSeries
     * @mixes commonProps.reduction
     * @mixes commonProps.openValueField
     */
    return {

        /**
         * @property
         * @memberof stockSeries
         * @type {string}
         * @default onlyPoint
         */

        hoverMode: "onlyPoint"
    };
};