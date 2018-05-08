(function () {
    'use strict';

    angular
        .module('i.employees')
        .component('chart', {
            templateUrl: '/app/modules/employees/components/chart/chart.html',
            controller: ChartController,
            bindings: {
                chart: '<'
            }
        });

    ChartController.$inject = ['employeesService', '$scope'];
    function ChartController(employeesService, $scope) {
        var ctrl = this;

        ctrl.$onInit = $onInit;
        ctrl.changeType = changeType;

        function $onInit() {
            debugger
            ctrl.chartConfig = {
                chart: {
                    type: 'line'
                },
                series: [{
                    data: ctrl.chart.duration,
                    name: 'Duration'
                }, {
                    data: ctrl.chart.beginning,
                    name: 'Time of beginning'
                }, {
                    data: ctrl.chart.ending,
                    name: 'Time of ending'
                }],
                title: {
                    text: 'Working day planning'
                }
            };
        }

        function changeType() {
            if (ctrl.chartConfig.chart.type === 'line') {
                ctrl.chartConfig.chart.type = 'bar';
            } else if (ctrl.chartConfig.chart.type === 'bar') {
                ctrl.chartConfig.chart.type = 'spline';
            } else if (ctrl.chartConfig.chart.type === 'spline') {
                ctrl.chartConfig.chart.type = 'scatter';
            } else if (ctrl.chartConfig.chart.type === 'scatter') {
                ctrl.chartConfig.chart.type = 'line';
            }
        }
    }

})();