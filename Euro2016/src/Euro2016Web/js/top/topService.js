module.exports = function (angApp) {
    angApp.service('topService', function ($http, $q) {
        this.getTopData = function () {
            var deferred = $q.defer();
            $http({ method: 'GET', url: '/api/top' }).then(
                function (response) {
                    deferred.resolve(response);
                },
                function (response) {
                    deferred.reject('Error');
                }
            );
            return deferred.promise;
        };
    });
};