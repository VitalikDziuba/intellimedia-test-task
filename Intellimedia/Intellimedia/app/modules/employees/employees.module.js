angular
    .module('i.employees', [])
    .config(routerConfig);

routerConfig.$inject = ['$stateProvider'];
function routerConfig($stateProvider) {
    $stateProvider
        .state('employees', {
            url: '/',
            template: '<employees employees="$resolve.employees"></employees>',
            resolve: {
                employees: resolveEmployees
            }
        }).state('chart', {
            url: '/chart',
            template: '<chart chart="$resolve.chart"></chart>',
            resolve: {
                chart: resolveChart
            }
        });
}

resolveEmployees.$inject = ['employeesService'];
function resolveEmployees(employeesService) {
    return employeesService.get(0);
}

resolveChart.$inject = ['employeesService'];
function resolveChart(employeesService) {
    return employeesService.getChart();
}
