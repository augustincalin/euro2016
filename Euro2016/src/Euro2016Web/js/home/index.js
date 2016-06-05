module.exports = function (angApp) {
    require('./homeService')(angApp);
    require('./homeCtrl')(angApp);
};