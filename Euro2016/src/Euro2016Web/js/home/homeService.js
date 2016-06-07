module.exports = function (angApp) {
    angApp.service('homeService', function ($http, $q) {
        this.getHomeData = function () {
            var deferred = $q.defer();
            $http({ method: 'GET', url: '/api/home' }).then(
                function (response) {
                    deferred.resolve(response);
                },
                function (response) {
                    deferred.reject('Error');
                }
            );
            return deferred.promise;
        };

        this.updateScore = function (matchId, isOne, value) {
            return $http.post('/api/home/updatescore', {
                'MatchId': matchId,
                'IsOne': isOne,
                'Value': value
            });
        };

        this.updateName = function(name){
            return $http.post('/api/home/updatename', {
                'Name': name
            });
        }
    });
};