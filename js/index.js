var angular = require('angular');
require('angular-animate');
require('angular-aria');
require('angular-messages');
require('angular-material');

var app = angular.module('euro2016', ['ngMaterial', 'ngMessages']);
app.run(function ($log) {
    $log.debug('app started...');
});
