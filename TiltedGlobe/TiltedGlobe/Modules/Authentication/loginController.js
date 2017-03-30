angular.module('TiltedGlobe')
    .controller('loginController',
    [
        '$scope', 'dataService', '$window', '$location', '$timeout', '$state',
        function ($scope, dataService, $window, $location, $timeout, $state) {
            $scope.loginForm = {
                grant_type: 'password'
            };
            $scope.ladda = {
                login: false
            };

            $scope.login = function() {
                $scope.ladda.login = true;
                dataService.upsert('oauth/token', $scope.loginForm, null, true).then(function (data) {
                    dataService.setToken(data.access_token);
                    //TODO: must fix crappy but ngstorage needs this to be sure token is saved
                    $timeout(function() {
                        $window.location.href = '/Producer';
                    },110);
                }, function() {
                    $scope.ladda.login = false;
                    $scope.errorMessage = 'Invalid Usermame or Password.';
                });
            };

            $scope.forgotPassword = function() {
                $scope.ladda.password = true;
                dataService.upsert('accounts/user/forgotPassword', $scope.loginForm, null, true).then(function(data) {
                    $scope.ladda.password = false;
                    $scope.forgotPasswordEmailed = true;
                }, function() {
                    $scope.ladda.password = false;
                    $scope.errorMessage = 'Invalid EMAIL';
                });
            };

        }
    ])

    .controller('confirmEmailController',
    [
        '$scope', 'dataService', '$location', '$state',
        function($scope, dataService, $location, $state) {
            $scope.loginForm = {
                grant_type: 'password'
            };
            $scope.ladda = {
                login: false
            };


            $scope.resetPassword = function(isValid) {
                if (isValid) {
                    $scope.ladda.reset = true;
                    dataService.upsert('accounts/ConfirmEmail', $scope.resetForm, null, true).then(function(data) {
                        $scope.ladda.reset = false;
                        $state.go('login');
                    }, function() {
                        $scope.ladda.reset = false;
                    });
                }
            };

            if (!$location.search().userId || !$location.search().code) {
                $state.go('login');
                return;
            }
            $scope.resetForm = {};
            $scope.resetForm.userId = $location.search().userId;
            $scope.resetForm.code = $location.search().code;
        }
    ])


.controller('resetPasswordController',
    [
        '$scope', 'dataService', '$location', '$state',
        function ($scope, dataService, $location, $state) {
            $scope.loginForm = {
                grant_type: 'password'
            };
            $scope.ladda = {
                login: false
            };


            $scope.resetPassword = function (isValid) {
                if (isValid) {
                    $scope.ladda.reset = true;
                    dataService.upsert('accounts/user/resetPassword', $scope.resetForm, null, true).then(function (data) {
                        $scope.ladda.reset = false;
                        $state.go('login');
                    }, function () {
                        $scope.ladda.reset = false;
                    });
                }
            };

            if (!$location.search().userId || !$location.search().code) {
                $state.go('login');
                return;
            }
                $scope.resetForm = {};
                $scope.resetForm.userId = $location.search().userId;
                $scope.resetForm.token = $location.search().code;
        }
    ]);

