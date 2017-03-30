angular.module('TiltedGlobe')
.directive('emailAvailableValidator', [
    '$http',
    '$q',
    'dataService',

    function ($http, $q, dataService) {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {
                ngModel.$asyncValidators.emailAddress = function (modelValue, viewValue) {
                    var deferred = $q.defer();
                    dataService.get('accounts/users/isemailavailable?username=' + encodeURIComponent(modelValue)).then(
                        function resolved(data) {
                            return data.isAvailable ? deferred.resolve() : deferred.reject();
                        }, function rejected() {
                            //add a global error catch
                            return deferred.reject();
                        });
                    return deferred.promise;
                };
            }
        };
    }]);