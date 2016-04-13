(function (module) {

    var loginRedirect = function ($injector) {
        
        var loginUrl = "/login";
        var notFoundUrl = "/404";

        var lastPath = "";
        this.setLoginUrl = function (value) {
            loginUrl = value;
        };

        this.$get = function ($q, $location) {
                return {
                responseError: function (response) {
                    if (response.status == 401) {
                        lastPath = $location.path();
                        $location.path(loginUrl);
                    }
                    else if (response.status == 404) {
                      $location.path(notFoundUrl);
                    }

                    return $q.reject(response);
                },

                redirectPreLogin: function () {
                    if (lastPath) {
                        $location.path(lastPath);
                        lastPath = "";
                    } else {
                        $location.path("/");
                    }
                },
                redirectLogin: function () {
                   $location.path("/login");
                }
            };
        };
    };

    module.provider("loginRedirect", loginRedirect);
    module.config(function($httpProvider) {
        $httpProvider.interceptors.push("loginRedirect");
    });

}(angular.module("common")))