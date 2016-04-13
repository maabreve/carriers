(function (module) {
    var carriersService = function ($http, $q, $log) {
        var getAll = function () {
            var deferred = $q.defer();
            $http.get('/api/carriers')
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data, status);
                });
            return deferred.promise;
        };

        var get = function (id) {
            var deferred = $q.defer();
            $http.get('/api/carriers/' + id)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data, status);
                });
            return deferred.promise;
        };


        var post = function (name, description) {
            var deferred = $q.defer();
            $http.post('/api/postCarrier/' + name + '/' + description)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data);
                    $log.error(data, status);
                });

            return deferred.promise;
        };

        var put = function (id, name, description) {
            var deferred = $q.defer();
            $http.put('/api/putCarrier/' + id + '/' + name + '/' + description)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data);
                    $log.error(data, status);
                });

            return deferred.promise;
        };

        var deleteCarrier = function (id) {
            var deferred = $q.defer();
            $http.delete('/api/deleteCarrier/' + id)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data);
                    $log.error(data, status);
                });

            return deferred.promise;
        };

        var getRatings = function (carrierId) {
            var deferred = $q.defer();
            $http.get('/api/carriers/' + carrierId + '/ratings')
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data, status);
                });
            return deferred.promise;
        };

        var postRating = function (carrierId, ratingValue, ratingComment, userId, userName) {
            var deferred = $q.defer();
            $http.post('/api/postRating/' + carrierId + '/' + ratingValue + '/' + ratingComment + '/' + userId + '/' + userName)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data);
                    $log.error(data, status);
                });

            return deferred.promise;
        };


        return {
            get: get,
            getAll: getAll,
            post: post,
            put: put,
            deleteCarrier: deleteCarrier,
            getRatings: getRatings,
            postRating: postRating
        }
    };

    module.factory("carriersService", carriersService);

}(angular.module("mainApp")))
