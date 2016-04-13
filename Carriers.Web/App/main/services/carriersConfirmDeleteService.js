(function (module) {

    var carriersConfirmDelete= function ($modal) {
        return function (carrier) {
            var options = {
                templateUrl: "app/main/templates/carriers/carriers-confirm-delete.html",
                controller: function () {
                    this.carrier = carrier;
                },
                controllerAs: "model",

            };
            return $modal.open(options).result;
        };
    };

    module.factory("carriersConfirmDelete", carriersConfirmDelete);

}(angular.module("mainApp")));
