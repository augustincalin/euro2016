module.exports = function (angApp) {
    angApp.controller('topCtrl', function ($scope, topService) {
        topService.getTopData().then(
    function (response) {
        $scope.users = response.data;
    },
    function (response) {
        console.log(response);
    }
);


    });
};