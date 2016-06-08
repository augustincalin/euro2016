module.exports = function (angApp) {
    angApp.controller('mainCtrl', function ($scope, homeService, $timeout, $mdToast, $anchorScroll, $location, $state) {

        $scope.isDataLoaded = false;

        homeService.getHomeData().then(
            function (response) {
                $scope.vm = response.data;
                $timeout(function () { $scope.isDataLoaded = true; $anchorScroll('nextMatches'); }, 2000);
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

        var showNotification = function (message, theme) {
            $mdToast.show(
              $mdToast.simple().textContent(message).hideDelay(500).theme(theme)
            );
        };

        $scope.gotoHelp = function () {
            $state.go('help');
        };

        $scope.gotoHome = function () {
            $state.go('home');
        };

        $scope.gotoTop = function () {
            $state.go('top');
        };

        $scope.gotoGroup = function (groupId) {
            $state.go('group');
        };

    });
};