'use strict';
registrationModule.controller("InstructorsController", function ($scope, bootstrappedData) {
    $scope.instructors = bootstrappedData.instructors;
});