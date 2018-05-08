/* App Module */
angular
    .module('intellimedia', [
        'ui.router',
        'ui.bootstrap',
        'highcharts-ng',
        'swangular',
        'i.employees'])
    .config(config);

config.$inject = ['$locationProvider', '$httpProvider', '$urlRouterProvider'];
function config($locationProvider, $httpProvider, $urlRouterProvider) {
    $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    $urlRouterProvider.otherwise('/dashboard');
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}