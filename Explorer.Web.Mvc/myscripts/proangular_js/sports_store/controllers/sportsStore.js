( // 1.
   function () //2.
   { // 3.
       angular.module("sportsStore")
           .constant("dataUrl", "/myscripts/proangular_js/sports_store/data/products.json")
           .controller("sportsStoreCtrl", function($scope, $http, dataUrl) {
               $scope.data = {};
           $http.get(dataUrl)
               .success(function(data) {
                   $scope.data.products = data;
               })
               .error(function(error) {
                   $scope.data.error = error;
               });
       });
   }() // 4.
); // 5.