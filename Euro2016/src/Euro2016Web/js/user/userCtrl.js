module.exports = function(angApp) {
    angApp.controller('userCtrl', function($scope, userService, $stateParams) {
        console.log($stateParams.id);
        userService.getUserData($stateParams.id).then(
            function(response) {
                $scope.vm2 = response.data;
            },
            function(response) {
                console.log(response);
            }
        );

    });
};