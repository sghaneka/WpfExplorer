'use strict';
registrationModule.factory('accountRepository', function ($http, $q) {
    return {
        save: function (instructor) {
            var deferred = $q.defer();
            $http.post('/Account/Save', instructor).success(function () { deferred.resolve(); }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        }
    }
});