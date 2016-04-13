(function(module) {

    module.config(function($provide) {
        $provide.decorator("$log", function($delegate, $injector) {
      
            var log = function(message) {
                var toaster = $injector.get("toaster");
                toaster.pop('info', message);
                return $delegate.log(message);
            };

            var warn = function(message) {
                var toaster = $injector.get("toaster");
                toaster.pop('warning', message);
                return $delegate.info(message);
            };

            var info = function(message) {
                var toaster = $injector.get("toaster");
                toaster.pop('info', message);
                return $delegate.info(message);
            };

            var error = function (message) {
                 var toaster = $injector.get("toaster");
                toaster.pop('error', 'Internal Exception');
                return $delegate.info(message);
            };

            return {
                log: log,
                warn: warn,
                info: info,
                error: error
            };
        });
    });

}(angular.module("common")));