var angular = require('angular');
require('angular-animate');
require('angular-aria');
require('angular-messages');
require('angular-material');
var uirouter = require('angular-ui-router');

require('oclazyload');

require('style!css!../node_modules/angular-material/angular-material.css');
require('../styles/app.less');

var app = angular.module('euro2016', ['ngMaterial', 'ngMessages', uirouter, 'oc.lazyLoad']);

app.run(function ($log) {
    $log.debug('app started...');
});
require('./home')(app);
require('./top')(app);
require('./user')(app);
require('./config')(app, angular);

