//we initialize the module name to 'app.controllers'
// app.js will search for a module called 'app.controllers' and will find this one and inject it
angular.module('app.controllers', [])

.controller('MoviesController', function ($scope,$http) {
    $http({
        method: 'GET',
        url: 'http://localhost:49863/api/movies'
    })
    .success(function (data) {
       $scope.movies = data;
    })
    .error(function (data) {
        alert("Http Request Failed!!!  =(");
    });
    
});