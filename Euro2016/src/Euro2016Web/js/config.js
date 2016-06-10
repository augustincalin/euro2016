﻿module.exports = function (angApp, angular) {
    angApp.config(['$stateProvider', '$locationProvider', '$urlRouterProvider', function ($stateProvider, $locationProvider, $urlRouterProvider) {
        //$locationProvider.hashPrefix('!');

        $urlRouterProvider.otherwise('/home');
        //$locationProvider.html5Mode({
        //    enabled: true,
        //    requireBase: false
        //});

        $stateProvider
            .state('home', {
                url: '/home',
                template: require('./home/home.html'),
                controller: 'homeCtrl'

            })
            .state('help', {
                url: '/help',
                template: require('./help/help.html')
            })
            .state('top', {
                url: '/top',
                template: require('./top/top.html'),
                controller: 'topCtrl'
            })
            .state('user', {
                url: '/user/:id',
                template: require('./user/user.html')
            })
            .state('group', {
                url: '/group',
                template: require('./group/group.html')
            })
        //.state('page4', {
        //    url: '/page4',
        //    templateProvider: ['$q', function ($q) {
        //        var deferred = $q.defer();
        //        require.ensure(['./page4/page4.html'], function () {
        //            var template = require('./page4/page4.html');
        //            deferred.resolve(template);
        //        });
        //        return deferred.promise;
        //    }],
        //    controller: 'Page4Controller',
        //    controllerAs: 'test',
        //    resolve: {
        //        foo: ['$q', '$ocLazyLoad', function ($q, $ocLazyLoad) {
        //            var deferred = $q.defer();
        //            require.ensure([], function () {
        //                var module = require('./page4/page4Module.js')(Angular);
        //                $ocLazyLoad.load({
        //                    name: 'page4App'
        //                });
        //                deferred.resolve(module);
        //            });

        //            return deferred.promise;
        //        }]
        //    }
        //});
    }]);

};

