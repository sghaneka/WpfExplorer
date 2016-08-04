(function() {
    angular.module("eventsApp")
        .controller("EventController", function ($scope, eventData) {
            $scope.snippet = "<span style='color:red'>hi there</span>";

            $scope.boolValue = true;
            $scope.sortorder = 'name';

            $scope.mystyle = { color: 'red' };
            $scope.myclass = "blue";
        $scope.buttonDisabled = true;

            // promise service

        /*$scope.event = eventData.getEvent().then(
            function(event) {
                $scope.event = event;
            },
            function(status) {
                console.log(status);
            });*/

        eventData.getEvent().$promise.then(function(event) {
            $scope.event = event;
            console.log(event);
        }, function(response) {
            console.log(response);
        });
        

            $scope.upVoteSession = function(session) {
                session.upVoteCount++;
            }

            $scope.downVoteSession = function (session) {
                if (session.upVoteCount > 0)
                session.upVoteCount--;
            }

        });

})();
