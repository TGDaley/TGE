angular.module('TiltedGlobe')
.controller('viewerRegistrationController',
    ['$scope', '$stateParams', '$location', 'dataService', 'viewerRegistrationService', '$state','$window',
    function ($scope, $stateParams, $location, dataService, viewerRegistrationService, $state, $window) {
        
        $scope.viewerService = viewerRegistrationService;
        $scope.stepTitles = [];
        $scope.submit = function () {
            viewerRegistrationService.form.viewerRegistration.$setSubmitted();
            if (viewerRegistrationService.form.viewerRegistration.eSignature) {
                viewerRegistrationService.form.viewerRegistration.eSignature.$setValidity("signatureDoesntMatch", viewerRegistrationService.isSignatureValid());
            }
            var isValid = viewerRegistrationService.form.viewerRegistration.$valid;
            if (isValid && viewerRegistrationService.user  && !viewerRegistrationService.user.state && viewerRegistrationService.user.country === 'US') isValid = false;
            if (isValid) {
                if (viewerRegistrationService.shouldRegister()) {
                    $scope.ladda.register = true;
                    dataService.upsert('accounts/register', viewerRegistrationService.user).then(function() {
                            $scope.ladda.register = false;
                            $state.go(viewerRegistrationService.uiStates[viewerRegistrationService.step]);
                            viewerRegistrationService.step += 1;
                        },
                        function (data) {
                            $scope.ladda.register = false;
                            //TODO: firgure out error handling maybe
                        });
                    return;
                }
                viewerRegistrationService.form.viewerRegistration.$setPristine();
                if (viewerRegistrationService.step === 1) {
                    viewerRegistrationService.setUiStates();
                    $scope.ladda.register = true;
                    viewerRegistrationService.captchaValidator.isValid().then(function() {
                        $state.go(viewerRegistrationService.uiStates[viewerRegistrationService.step]);
                        viewerRegistrationService.step += 1;
                        $scope.ladda.register = false;
                    }, function() {
                        $scope.ladda.register = false;
                    });
                } else {
                    $state.go(viewerRegistrationService.uiStates[viewerRegistrationService.step]);
                    viewerRegistrationService.step += 1;
                }

            }
        };

        $scope.previousStep = function() {
            if (viewerRegistrationService.step === 1) {
                $window.location.href = '/';
                return;
            }
            viewerRegistrationService.step -= 1;
            $state.go(viewerRegistrationService.uiStates[viewerRegistrationService.step - 1]);
        };

        $scope.setLastStep = function () {
            if ($scope.form.type === 'normal') {
                $scope.stepTitles = [
                    { name: 'Select Account Type' },
                    { name: 'Single Viewer Registration' },
                    { name: 'Confirmation', fontAwesomeClass: { 'fa': true, 'fa-check-square-o': true } }];
            }
            else {
                $scope.stepTitles = [
                    { name: 'Select Account Type' },
                    { name: 'Commercial Viewer Registration' },
                    { name: 'Commercial Registration' },
                    { name: 'Commercial Viewer Registration' },
                    { name: 'Confirmation', fontAwesomeClass: { 'fa': true, 'fa-check-square-o': true }  }];
            }
        };

        $scope.backToLogin = function() {
            $scope.changeView('login');
        };

        $scope.ladda = {
            register: false
        };
    }
    ])

.controller('wizardViewerController',
    ['$scope', 'viewerRegistrationService',
        function ($scope, viewerRegistrationService) {
            $scope.user = {};
            $scope.form = {};
            $scope.captchaValidator = {};
            viewerRegistrationService.form = $scope.form;
            viewerRegistrationService.user = $scope.user;
            viewerRegistrationService.captchaValidator = $scope.captchaValidator;
            viewerRegistrationService.step = 1;
        }])

.factory('viewerRegistrationService',
[
    function () {
        var uiStates = [];
        var headers = [];
        var step = 1;
        var user = {};
        var shouldRegister = function () {
            if (this.user.type === 'normal') {
                return this.step === 2;
            }
            return this.step === 3;
        };
        var setUiStates = function() {
            if (this.user.type === 'normal') {
                this.uiStates = ['viewer.stepone', 'viewer.steptwo', 'viewer.stepthree'];
                this.headers = ['SELECT AN ACCOUNT TYPE', 'SINGLE VIEWER REGISTRATION', 'CONFIRMATION'];
            } else {
                this.uiStates = ['viewer.stepone', 'viewer.steptwocommercial', 'viewer.stepthreecommercial', 'viewer.stepfourcommercial', 'viewer.stepfivecommercial'];
                this.headers = ['SELECT AN ACCOUNT TYPE', 'COMMERCIAL VIEWER REGISTRATION', 'COMMERCIAL REGISTRATION', 'COMMERCIAL VIEWER REGISTRATION', 'CONFIRMATION'];
            }
        };
        var isSignatureValid = function () {
            return this.user.firstName + ' ' + this.user.lastName === this.user.eSignature;
        };
        var isConfirmation = function() {
            if (this.user.type === 'normal') {
                return this.step === 3;
            }
            return this.step === 4;
        };

        return {
            step: step,
            user: user,
            shouldRegister: shouldRegister,
            setUiStates: setUiStates,
            uiStates: uiStates,
            isSignatureValid: isSignatureValid,
            headers: headers,
            isConfirmation: isConfirmation
        }
    }
]);