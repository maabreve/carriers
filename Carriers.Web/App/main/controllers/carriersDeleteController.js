(function (module) {

    var carriersDeleteController = function ($state, $timeout, $filter, $stateParams, carriersService) {
        var model = this;
        
        model.name = $stateParams.name;

        //confirm delete
        model.confirmDelete = function () {
            carriersService.deleteCarrier($stateParams.id).then(function () {
                    model.goToList();
                }
            );
        };

        //navegacao
        model.goToList = function () {
            $state.go('carriers-list');
        }

    };

    module.controller("carriersDeleteController", carriersDeleteController);

}(angular.module("mainApp")));
