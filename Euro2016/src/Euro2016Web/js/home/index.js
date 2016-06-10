module.exports = function (angApp) {
    require('./homeService')(angApp);
    require('./mainService')(angApp);
    require('./homeCtrl')(angApp);
    require('./mainCtrl')(angApp);
};