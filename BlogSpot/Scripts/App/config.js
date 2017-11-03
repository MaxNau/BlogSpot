angular.module("blogApp").config(function ($routeProvider) {
    $routeProvider.
   when('/contact', {
       templateUrl: '/home/contact',
       controller: 'contactController'
   })
    .when('/posts', {
        templateUrl: '/home/posts',
        controller: 'postsController'
    })
    .when('/about', {
        templateUrl: '/home/aboutme',
        controller: 'aboutController'
    })
    .when('/post/:year/:month/:day/:title', {
        templateUrl: '/home/posts',
        controller: 'postsController'
    })
    .when('/', {
        templateUrl: '/home/posts',
        controller: 'postsController'
    });
});