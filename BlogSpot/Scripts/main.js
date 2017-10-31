require.config({
    baseUrl: "scripts",
    paths: {
        'angular': 'angular',
        'angular-route': 'angular-route',
        'jquery': 'jquery-3.2.1.js',
        'aboutController': 'app/controllers/aboutController',
        'postsController': 'app/controllers/postsController',
        'contactController': 'app/controllers/contactController',
        'app': 'app/app'
    },
    shim: {
        'angular': {
            exports: 'angular'
        },
        'app': ['angular-route'],
        'angular-route': ['angular']
    },

    deps: ['app']
});