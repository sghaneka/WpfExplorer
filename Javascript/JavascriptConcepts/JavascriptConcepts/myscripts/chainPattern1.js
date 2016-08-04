
// capture the this variable, if caller isn't trusted....
var Calc2 = function (start) {

    var that = this;

    this.add = function (x) {
        start = start + x;
        return that;
    };
    this.multiply = function (x) {
        start = start * x;
        return that;
    };
    this.equals = function (callback) {
        callback(start);
        return that;
    };
};
var Calc = function (start) {

    this.add = function (x) {
        start = start + x;
        return this;
    };
    this.multiply = function (x) {
        start = start * x;
        return this;
    };
    this.equals = function (callback) {
        callback(start);
        return this;
    };
};
new Calc(0)
    .add(1)
    .add(2)
    .multiply(3)
    .equals(function (result) {
        console.log(result);
    });