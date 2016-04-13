(function (module) {

    var carriersListController = function ($state, $timeout, $filter, $log, carriersService) {
        var model = this;

        //inicializacao variaveis
        model.carriers = [];
           
        //carregamento lista
        carriersService.getAll()
           .then(function (carriers) {
               model.carriers = carriers;
           });

        //navegacao
        model.goToNew = function () {
            $state.go('carriers-edit');
        };

        model.goToEdit = function (id) {
            $state.go('carriers-edit', { id: id } );
        };

        //delete carrier
        model.goToDelete = function (id, name) {
            $state.go('carriers-delete', { id: id, name: name });
        }


        //ordenação colunas
        model.predicate = 'Id';
        model.reverse = false;
        model.order = function (predicate) {
            model.reverse = (model.predicate === predicate) ? !model.reverse : false;
            model.predicate = predicate;
        };

    };

    module.controller("carriersListController", carriersListController);

}(angular.module("mainApp")));
