angular.module('TiltedGlobe')
.directive('recaptcha', ['dataService', '$q', function (dataService, $q) {
    return {
        restrict: 'E',
        templateUrl: '/Authentication/Recaptcha',
        scope: {
            form: '=',
            validator:'='
        },
        link: function (scope, $this, attrs) {
            scope.captcha = {};
            scope.reloadCaptcha = function () {
                Recaptcha.reload();
            };
            scope.validator.isValid = function () {
                var deferred = $q.defer();
                dataService.upsert('accounts/validatecaptcha', scope.captcha)
                    .then(function() {
                        deferred.resolve();
                        },
                        function () {
                            deferred.reject();
                            scope.captchaError = true;
                            Recaptcha.reload();
                        });
                return deferred.promise;
            };
        }
    };
}]);