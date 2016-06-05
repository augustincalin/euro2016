module.exports = function (angApp) {
    angApp.controller('homeCtrl', function ($scope, homeService) {
        homeService.getHomeData().then(
            function (response) {
                $scope.vm = response.data;
            },
            function (response) {
                console.log(response);
            }
        );

        $scope.score1Change=function(matchId, score){
            debugger;
        }
        $scope.score2Change = function(matchId, score){
            debugger;
        }
    });
};