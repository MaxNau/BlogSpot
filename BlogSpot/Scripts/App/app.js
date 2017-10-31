define(function () {
    var app = angular.module("blogApp", ['ngRoute']);

    app.config(function ($routeProvider, $controllerProvider) {

        app.register = {
            controller: $controllerProvider.register
        };

        function resolveController(names) {
            return {
                load: ['$q', '$rootScope', function ($q, $rootScope) {
                    var defer = $q.defer();
                    require(names, function () {
                        defer.resolve();
                        $rootScope.$apply();
                    });
                    return defer.promise;
                }]
            }
        }

        $routeProvider.
       when('/contact', {
           templateUrl: '/home/contact',
           controller: 'contactController',
           resolve: resolveController(['contactController'])
       })
        .when('/posts', {
            templateUrl: '/home/posts',
            controller: 'postsController',
            resolve: resolveController(['postsController'])
        })
        .when('/about', {
            templateUrl: '/home/aboutme',
            controller: 'aboutController',
            resolve: resolveController(['aboutController'])
        })
        .when('/', {
            templateUrl: '/home/posts',
            controller: 'postsController',
            resolve: resolveController(['postsController'])
        });
    });

});