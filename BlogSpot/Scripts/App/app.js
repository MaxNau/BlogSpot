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
        .when('/post/:year/:month/:day/:title', {
            templateUrl: '/home/post',
            controller: 'postController',
            resolve: resolveController(['postController'])
        })
        .when('/newpost', {
            templateUrl: '/home/newPost',
            controller: 'newPostController',
            resolve: resolveController(['newPostController'])
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

    app.controller("mainController", function ($scope, $http) {
        var thunder = new Audio("https://www.zedge.net/d2w/4/474042/831146428/dl/");
        $scope.thunder = function () {
            thunder.addEventListener('ended', function() {
                this.currentTime = 0;
                this.play();
            }, false);
            thunder.play();
        }

        $scope.stopThunder = function () {
            thunder.currentTime = 0;
            thunder.pause();
        }
    });
});