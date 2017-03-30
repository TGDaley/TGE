angular.module('TiltedGlobe')
.controller('producerRegistrationController',
    ['$scope', '$stateParams', '$location', 'dataService', '$window', 'producerRegistrationService','$state',
    function ($scope, $stateParams, $location, dataService, $window, producerRegistrationService, $state) {
        var uiStates = ['producer.stepone', 'producer.steptwo', 'producer.stepthree'];
        $scope.producerService = producerRegistrationService;
        $scope.producerRegistration1 = function () {
            var user = producerRegistrationService.user;
            $scope.form = producerRegistrationService.form.producerRegistration;
            
            $scope.form.$setSubmitted();
            if ($scope.form.eSignature) {
                $scope.form.eSignature.$setValidity("signatureDoesntMatch", producerRegistrationService.isSignatureValid());
            }
            var isValid = $scope.form.$valid;
            if (isValid && !user.state && user.country === 'US') isValid = false;
            if (isValid) {
                if ($scope.form) $scope.form.$setPristine();
                $scope.ladda.register = true;
                if ($scope.producerService.step === 1) {
                    producerRegistrationService.captchaValidator.isValid().then(function() {
                        $state.go(uiStates[$scope.producerService.step]);
                        $scope.producerService.step += 1;
                        $scope.ladda.register = false;
                    }, function() {
                        $scope.ladda.register = false;
                    });
                } else {
                    dataService.upsert('accounts/register', user)
                        .then(function() {
                                $window.location.href = '/';
                            },
                            function(data) {
                                //TODO: firgure out error handling maybe
                            });
                }
            }
        };

        $scope.previousStep = function () {
            if ($scope.producerService.step === 1) {
                $window.location.href = '/';
                return;
            }
            $scope.producerService.step -= 1;
            $state.go(uiStates[$scope.producerService.step-1]);
        }
        $scope.ladda = {
            register: false
        };
    }
    ])


.controller('wizardProducerController',
    ['$scope', '$stateParams', '$location', 'dataService', '$window','producerRegistrationService',
        function ($scope, $stateParams, $location, dataService, $window, producerRegistrationService) {
            $scope.user = {};
            $scope.form = {};
            $scope.captchaValidator = {};
            producerRegistrationService.form = $scope.form;
            producerRegistrationService.user = $scope.user;
            producerRegistrationService.captchaValidator = $scope.captchaValidator;


        }])

.factory('producerRegistrationService',
[
    function() {
        var step = 1;
        var user = {};
        var isSignatureValid = function () {
            return this.user.firstName + ' ' + this.user.lastName === this.user.eSignature;
        };
        return {
            step: step,
            user: user,
            isSignatureValid: isSignatureValid
        }
    }
]);

