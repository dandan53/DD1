var app = angular.module("DDApp", ['ngRoute']).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: MainCtrl, templateUrl: 'main.html' }).
            otherwise({ redirectTo: '/' });
    });

//TodoApp.controller(ListCtrl);

var MainCtrl = function ($scope, $location) {
    $scope.form = {};
   // $scope.form.name = "dan daniel";
   // $scope.form.phone = "052-1234561";
   
    $scope.title = "dan daniel";

    $scope.send = function() {
        alert($scope.form.name);
    };
};