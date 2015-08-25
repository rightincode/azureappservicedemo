(function () {
    
    var MainController = function ($scope, $resource, $window) {

        var processSignUp = function (newCustomer) {

            var customerService = $resource('https://microsoft-apiapp16171be174e6436fb62d93a5c56f8a33.azurewebsites.net/api/customers', {}, {
                query: { method: 'GET', isArray: false },
                save: { method: 'POST', isArray: false }
            });

            customerService.save(newCustomer).$promise.then(function() {
                $window.location.href = 'views/success.html';
            });
        };

        var newCustomer = { firstName: '', lastName: '', email: '', phone: '' };

        $scope.phoneNumberFormat = /^(?:\([2-9]\d{2}\)\ ?|(?:[2-9]\d{2}\-))[2-9]\d{2}\-\d{4}$/;
        $scope.newCustomer = newCustomer;
        $scope.processSignUp = processSignUp;

    };

    var app = angular.module('NewApp', ['ngResource']);
    app.controller('MainController', ['$scope', '$resource', '$window', MainController]);

}());