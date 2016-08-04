'use strict';
registrationModule.controller("AccountController", function ($scope, accountRepository, $location) {

    $scope.save = function (instructor) {
        $scope.error = false;
        accountRepository.save(instructor).then(function () { $location.url('Angular/RegistrationAjax/Instructors'); },
            function () { $scope.error = true; });
    }
});