module.exports = function (angApp, angular) {
    angApp.config(['$stateProvider', '$locationProvider', '$urlRouterProvider', function ($stateProvider, $locationProvider, $urlRouterProvider) {


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
                templateProvider:['$q', function($q){
                    var def = $q.defer();
                    require.ensure(['./help/help.html'], function () {
                        var template = require('./help/help.html');
                        def.resolve(template);
                    });
                    return def.promise;
                }]
            })
            .state('top', {
                url: '/top',
                templateProvider: ['$q', function ($q) {
                    var deferred = $q.defer();
                    require.ensure(['./top/top.html'], function () {
                        var template = require('./top/top.html');
                        deferred.resolve(template);
                    });
                    return deferred.promise;
                }],
                controller: 'topCtrl',
                resolve: {
                    foo: ['$q', '$ocLazyLoad', function ($q, $ocLazyLoad) {
                        var deferred = $q.defer();
                        require.ensure(['./top'], function () {
                            var module = require('./top')(angApp);
                            $ocLazyLoad.load({
                                name: 'euro2016'
                            });
                            deferred.resolve(module);
                        });

                        return deferred.promise;
                    }]
                }
            })
            .state('user', {
                url: '/user/:id',
                templateProvider: ['$q', function ($q) {
                    var deferred = $q.defer();
                    require.ensure(['./user/user.html'], function () {
                        var template = require('./user/user.html');
                        deferred.resolve(template);
                    });
                    return deferred.promise;
                }],
                controller: 'userCtrl',
                resolve: {
                    sss: ['$q', '$ocLazyLoad', function ($q, $ocLazyLoad) {
                        var deferred = $q.defer();
                        require.ensure(['./user/userService'], function () {
                            var module = require('./user/userService')(angApp);
                            $ocLazyLoad.load({
                                name: 'euro2016'
                            });
                            deferred.resolve(module);
                        });

                        return deferred.promise;
                    }],
                    foo: ['$q', '$ocLazyLoad', function ($q, $ocLazyLoad) {
                        var deferred = $q.defer();
                        require.ensure(['./user'], function () {
                            var module = require('./user')(angApp);
                            $ocLazyLoad.load({
                                name: 'euro2016'
                            });
                            deferred.resolve(module);
                        });

                        return deferred.promise;
                    }]
                }
            });
    }]);

};

