(function() {
    angular.module("eventsApp")
        .controller("EditEventController", function ($scope, eventData) {

            $scope.saveEvent = function (event, newEventForm) {
                if (newEventForm.$valid) {
                    toastr.success('event ' + event.name + ' saved in progress...', 'call to save event');
                    eventData.save(event).$promise.then(
                        function(response) {
                            toastr.success('saved...');
                        }, function(response) {
                        toastr.fail('failed to save...');
                    });
                }
           
        };

        $scope.cancelEdit = function() {
            window.location = '/Events';
        };


    });

})();
