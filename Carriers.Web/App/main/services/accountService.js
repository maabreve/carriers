(function (module) {
    var accountService = function ($http, $q, $log) {
        
        var getCurrentUser= function () {
            var deferred = $q.defer();
            $http.get('/api/getCurrentUser')
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data, status);
                });
            return deferred.promise;
        };

        
        var getCurrentUserId = function () {
            var deferred = $q.defer();
            $http.get('/api/getCurrentUserId')
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data, status);
                });
            return deferred.promise;
        };

        return {
            getCurrentUser: getCurrentUser,
            getCurrentUserId: getCurrentUserId
        }
    };

    module.factory("accountService", accountService);

}(angular.module("mainApp")))
