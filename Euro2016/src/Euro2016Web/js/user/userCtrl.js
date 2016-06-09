module.exports = function (angApp) {
    angApp.controller('userCtrl', function ($scope, userService, $stateParams) {
        userService.getUserData($stateParams.id).then(
    function (response) {
        $scope.vm = response.data;
    },
    function (response) {
        console.log(response);
    }
);


    });
};