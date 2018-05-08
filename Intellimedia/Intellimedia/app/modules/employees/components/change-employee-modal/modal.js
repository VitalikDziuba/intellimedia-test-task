(function () {
    'use strict';

    angular
        .module('i.employees')
        .component('changeEmployeeModal', {
            templateUrl: '/app/modules/employees/components/change-employee-modal/modal.html',
            controller: ModalController,
            bindings: {
                resolve: '<',
                close: '&'
            }
        });

    ModalController.$inject = ['employeesService'];
    function ModalController(employeesService) {
        var ctrl = this;
        var edit = 'edit';
        var create = 'create';

        ctrl.$onInit = $onInit;
        ctrl.submit = submit;
        ctrl.genders = ['Male', 'Female'];

        function $onInit() {
            ctrl.employee = ctrl.resolve.type === edit ? angular.copy(ctrl.resolve.employee) : {};
        }

        function submit() {
            if (ctrl.employeeForm.$valid) {
                ctrl.progress = true;
                if (ctrl.resolve.type === edit) {
                    employeesService.edit(ctrl.employee).then(onSuccess, onError);
                } else {
                    employeesService.add(ctrl.employee).then(onSuccess, onError);
                }
            }
        }
        var onSuccess = function (response) {
            ctrl.progress = false;
            ctrl.close({ $value: response.data });
        };

        var onError = function () {
            ctrl.progress = false;
            alert('worl');
        };

    }

})();
