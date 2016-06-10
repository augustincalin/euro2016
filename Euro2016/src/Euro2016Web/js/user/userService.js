module.exports = function (angApp) {
    angApp.service('userService', function ($http, $q) {
        this.getUserData = function (userId) {
            var deferred = $q.defer();
            $http({ method: 'GET', url: '/api/user/getuser/:id', params: {id: userId}}).then(
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