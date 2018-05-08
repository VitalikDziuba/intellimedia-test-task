(function () {
    'use strict'
    angular
        .module('intellimedia')
        .service('employeesService', employeesService);

    employeesService.$inject = ['$http'];
    function employeesService($http) {
        var service = this;

        service.get = get;
        service.add = add;
        service.edit = edit;
        service.remove = remove;
        service.getChart = getChart;

        function get(skip) {
            return $http.get('employee/get', { params: { skip: skip } }).then(function (response) {
                if (response.data && response.data.employees) {
                    service.count = response.data.count;
                    return response.data.employees;
                }
            });
        }

        function add(employee) {
            return $http.post('employee/add', employee);
        }

        function edit(employee) {
            return $http.post('employee/edit', employee);
        }

        function remove(employee) {
            return $http.post('employee/remove', employee);
        }

        function getChart() {
            return $http.get('employee/chart').then(function (response) {
                return response.data;
            });
        }
    }
})();
    