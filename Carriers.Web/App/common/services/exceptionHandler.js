(function(module) {

    module.config(function($provide) {
        $provide.decorator("$exceptionHandler", function($delegate, $injector) {
            return function(exception, cause) {
                $delegate(exception, cause);
            };
        });
    });

}(angular.module("common")));