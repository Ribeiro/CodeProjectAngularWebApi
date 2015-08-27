// Declares how the application should be bootstrapped. See: http://docs.angularjs.org/guide/module
angular.module('app',
    [
        // Dependency Inject Goes inside this array
        'ui.router',  // we inject/load ui-router for routing
        'app.controllers', // we inject/load the controllers
    ]
)
    .config(['$stateProvider',
        function ($stateProvider) {
            //UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router

            //Our routers, self explanatory
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: './View/Home.html'
                })
                .state('movies', {
                    url: '/movies',
                    templateUrl: './View/Movies.html',
                    controller: 'MoviesController'
                })
                .state('otherwise', {
                    url: '*path',
                    templateUrl: '/View/Error.html',
                    controller: 'ErrorCtrl'
                });
        }]

);