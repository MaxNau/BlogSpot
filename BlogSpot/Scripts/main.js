require.config({
    baseUrl: "scripts",
    paths: {
        'angular': 'angular',
        'angular-route': 'angular-route',
        'jquery': 'jquery-3.2.1',
        'aboutController': 'app/controllers/aboutController',
        'postsController': 'app/controllers/postsController',
        'contactController': 'app/controllers/contactController',
        'postController': 'app/controllers/postController',
        'mainController': 'app/controllers/mainController',
        'newPostController': 'app/controllers/newPostController',
        'app': 'app/app',
        'tinymce': 'tinymce/tinymce'
    },
    shim: {
        'angular': {
            exports: 'angular'
        },
        'tinymce' : {
            exports: 'tinymce'
        },
        'app': ['angular-route'],
        'angular-route': ['angular']
    },

    deps: ['app']
});

require(['angular', 'app'],
    function () {
        angular.bootstrap(document, ['blogApp']);
    }
);