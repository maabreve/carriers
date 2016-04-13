(function(module) {

    var addToken = function(currentUser, localStorage, $q, $window) {
        var USERKEY = "utoken";

        return {
            request: function (config) {
                if (currentUser.profile.token) {
                    var token = currentUser.profile.token;
                    config.headers.Authorization = "Bearer " + token;
                 
                }
                return $q.when(config); 
            }
        };
    };

    module.factory("addToken", addToken);
    module.config(function($httpProvider) {
        $httpProvider.interceptors.push("addToken");
    });

})(angular.module("common"));