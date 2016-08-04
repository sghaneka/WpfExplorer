registrationModule.factory('instructorRepository', function ($http, $q) {
    return {
        get: function () {
            var deferred = $q.defer();
            console.log('here');
            $http.get('/Instructors').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});