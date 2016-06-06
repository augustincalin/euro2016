module.exports = function (angApp) {
    angApp.controller('homeCtrl', function ($scope, homeService, $timeout) {

        $scope.isDataLoaded = false;

        homeService.getHomeData().then(
            function (response) {
                $scope.vm = response.data;
                $timeout(function () {  $scope.isDataLoaded = true; }, 2000);
            },
            function (response) {
                console.log(response);
            }
        );

        $scope.score1Change=function(matchId, score){
            if (score) {

            }
        }
        $scope.score2Change = function(matchId, score){
            if (score) {

            }
        }
    });
};