module.exports = function (angApp) {
    angApp.controller('topCtrl', function ($scope, topService) {

        $scope.users = {
            numLoaded_: 0,
            toLoad_: 0,
            items: [],

            getItemAtIndex: function (index) {
                if (index > this.numLoaded_) {
                    this.fetchMoreItems_(index);
                    return null;
                };
                return this.items[index];
            },

            getLength: function () {
                return this.numLoaded_ + 5;
            },

            fetchMoreItems_: function (index) {
                if (this.toLoad_ < index) {
                    this.toLoad_ += 5;
                    topService.getTopData().then(angular.bind(this, function (obj) {
                        this.items = this.items.concat(obj.data);
                        this.numLoaded_ = this.ToLoad_;
                    }));
                };
            }
        };
    });
};