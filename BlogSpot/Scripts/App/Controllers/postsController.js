define(['angular'], function (angular) {
    angular.module("blogApp").register.controller("postsController", function ($scope, $http) {
        $http.get('http://localhost:9992/api/test/get').then(function (data) {
            $scope.posts = data.data;
        });
    });
});


//angular.module("blogApp").controller("postsController", function ($scope) {

//});