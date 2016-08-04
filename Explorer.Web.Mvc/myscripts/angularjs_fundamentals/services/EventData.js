(function() {
    angular.module("eventsApp")
        .factory("eventDataHttp", function($http, $log, $q) {
            return {
                getEvent: function() {
                    var deferred = $q.defer();
                    $http({ method: 'GET', url: '/myscripts/angularjs_fundamentals/data/event1.json' }).success(function(data, status, headers, config) {
                        deferred.resolve(data);
                    }).error(function(data, status, headers, config) {
                        deferred.reject(status);
                    });
                    return deferred.promise;
                },
                save: function(event) {
                    event.id = 999;
                    return resource.save(event);
                }
            }
        })
        .factory("eventData", function ($q, $resource) {
        var resource = $resource('/api/EventsData/:id', { id: '@id' });
            return {
                getEvent: function() {
                    return resource.get({ id: 1 });
                },
                save: function (event) {
                    event.id = 999;
                    return resource.save(event);
                }
            }
        });
})();

      