module.exports = function (angApp) {
    angApp.service('homeService', function ($http, $q) {
        this.getHomeData = function () {
            var deferred = $q.defer();
            $http({ method: 'GET', url: '/api/home' }).then(
                function(response) {
                    deferred.resolve(response);
                },
                function(response) {
                    deferred.reject('Error');
                }
            );
            return deferred.promise;
        };
    });
};