(function () {
    var module = angular.module("mainApp", ["common", "ngAnimate", "toaster","ui.bootstrap",
        "ngMessages", "ui.router", "ngResource",  "angularUtils.directives.dirPagination"]);
    
    module.config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("carriers-list");

        $stateProvider
            .state("carriers-list", { url: "/carriers-list", templateUrl: "/app/main/templates/carriers/carriers-list.html" })
            .state("carriers-edit", { url: "/carriers-edit/:id", templateUrl: "/app/main/templates/carriers/carriers-edit.html" })
            .state("carriers-delete", { url: "/carriers-delete/:id/:name", templateUrl: "/app/main/templates/carriers/carriers-delete.html" })
    })

}());