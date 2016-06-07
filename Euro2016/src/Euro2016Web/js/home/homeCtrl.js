module.exports = function (angApp) {
    angApp.controller('homeCtrl', function ($scope, homeService, $timeout, $mdToast) {

        $scope.isDataLoaded = false;

        homeService.getHomeData().then(
            function (response) {
                $scope.vm = response.data;
                $timeout(function () { $scope.isDataLoaded = true; }, 2000);
            },
            function (response) {
                console.log(response);
            }
        );

        $scope.scoreChange = function (matchId, isOne, score) {
            if (score) {
                homeService.updateScore(matchId, isOne, score).then(
                    function (response) {
                        showNotification('Saved!', 'success-toast');
                    },
                    function (response) {
                        showNotification('Error :(', 'error-toast');
                    }
                );
            }
        };

        $scope.nameChange = function () {
            homeService.updateName($scope.vm.Name).then(
                function (response) {
                    showNotification('Saved!', 'success-toast');
                },
                function (response) {
                    showNotification('Error :(', 'error-toast');
                }
            );

        };

        showNotification = function (message, theme) {
            $mdToast.show(
              $mdToast.simple().textContent(message).hideDelay(500).theme(theme)
            );
        };

    });
};