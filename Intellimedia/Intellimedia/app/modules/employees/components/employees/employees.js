(function () {
    'use strict';

    angular
        .module('i.employees')
        .component('employees', {
            templateUrl: '/app/modules/employees/components/employees/employees.html',
            controller: EmployeesController,
            bindings: {
                employees: '<'
            }
        });

    EmployeesController.$inject = ['employeesService', '$uibModal'];
    function EmployeesController(employeesService, $uibModal) {
        var ctrl = this;
        var create = 'create';
        var edit = 'edit';
        var maxLength = 10;

        ctrl.employeesService = employeesService;

        ctrl.addEmployee = addEmployee;
        ctrl.editEmployee = editEmployee;
        ctrl.removeEmployee = removeEmployee;
        ctrl.changePage = changePage;

        function addEmployee() {
            var modalInstance = $uibModal.open({
                component: 'changeEmployeeModal',
                resolve: {
                    type: function () {
                        return create;
                    } 
                }
            });

            modalInstance.result.then(function (response) {
                employeesService.count++;
                if (response && ctrl.employees.length < maxLength) {
                    ctrl.employees.push(response);
                }
            });
        }

        function editEmployee(employee, index) {
            var modalInstance = $uibModal.open({
                component: 'changeEmployeeModal',
                backdrop: 'static',
                resolve: {
                    employee: function () {
                        return employee;
                    },
                    type: function () {
                        return edit;
                    } 
                }
            });

            modalInstance.result.then(function (response) {
                if (response) {
                    ctrl.employees[index] = response;
                }
            });
        }

        function removeEmployee(employee, index) {
            ctrl.progressRemove = true;
            employeesService.remove(employee).then(function onSuccess() {
                ctrl.progressRemove = false;
                employeesService.count--;
                ctrl.employees.splice(index, 1);
                if (!ctrl.employees.length) {
                    changePage(ctrl.currentPage--);
                }
            }, function onError() {
                ctrl.progressRemove = false;
            });
        }

        function changePage() {
            employeesService.get((ctrl.currentPage - 1) * 10).then(function (response) {
                ctrl.employees = response;
            });
        }
    }

})();