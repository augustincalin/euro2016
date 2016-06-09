module.exports = function (angApp) {
    require('./userService')(angApp);
    require('./userCtrl')(angApp);
};