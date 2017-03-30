angular.module('TiltedGlobe')
    .provider('authenticationRoute',
    [
        function() {
            var routes = [
                {
                    name: 'login',
                    config: {
                        url: '/',
                        views: {
                            'mainContent': {
                                templateUrl: '/Authentication/Login',
                                controller: 'loginController'
                            }
                        },
                    }
                },
                {
                    name: 'forgotpassword',
                    config: {
                        url: '/ForgotPassword',
                        views: {
                            'mainContent': {
                                templateUrl: '/Authentication/ForgotPassword',
                                controller: 'loginController'
                            },
                            'header': {
                                template: '<span class="largeLabel">FORGOTTEN PASSWORD</span>' +
                                    '<tg-button button-class="button-blue stretch" text="Back To Login" text-label-class="buttonLabel" ui-sref="login"></tg-button>'
                            }
                        }
                    }
                },
                {
                    name: 'resetpassword',
                    config: {
                        url: '/ResetPassword',
                        views: {
                            'mainContent': {
                                templateUrl: '/Authentication/ResetPassword',
                                controller: 'resetPasswordController'
                            },
                            'header': {
                                template: '<span class="largeLabel">SET PASSWORD</span>'
                            }
                        }
                    }
                },
                {
                    name: 'confirmsetpassword',
                    config: {
                        url: '/ConfirmEmail',
                        views: {
                            'mainContent': {
                                templateUrl: '/Authentication/ResetPassword',
                                controller: 'confirmEmailController'
                            },
                            'header': {
                                template: '<span class="largeLabel">SET PASSWORD</span>'
                            }
                        }
                    }
                },
                {
                    name: 'register',
                    config: {
                        url: '/Register',
                        views: {
                            'mainContent': {
                                templateUrl: '/Authentication/Register',
                                controller: 'loginController'
                            },
                            'header': {
                                template: '<span class="largeLabel">NEW REGISTRATION</span>' +
                                    '<tg-button button-class="button-blue" text="Back To Login" text-label-class="buttonLabel" ui-sref="login"></tg-button>'
                            }
                        }

                    }
                },
                {
                    name: 'producer',
                    config: {
                        url: '/Register/Producer',
                        abstract: true,
                        views: {
                            'header': {
                                template: '<div>' +
                                    '<span class="largeLabel">PRODUCER REGISTRATION</span>' +
                                    '</div>' +
                                    '<div>' +
                                    '<span class="largeLabel">STEP {{producerService.step}} OF 3</span>' +
                                    '</div>',
                                controller: 'producerRegistrationController'
                            },
                            'mainContent': {
                                template: '<form name="form.producerRegistration" ng-controller="wizardProducerController" class="small-font" novalidate><div ui-view></div></form>'
                            },
                            'footer': {
                                template: '<div class="fItem">' +
                                    '<tg-button button-class="button-gray stretch" left-icon-class="fa fa-arrow-left" text="Previous" text-label-class="buttonLabel" on-click="previousStep()"></tg-button>' +
                                    '</div>' +
                                    '<div class="fItem" ng-if="step !== 3">' +
                                    '<tg-button button-class="button-blue stretch" right-icon-class="fa fa-arrow-right" text="Next" text-label-class="buttonLabel" on-click="producerRegistration1()" action="ladda.register"></tg-button>' +
                                    '</div>' +
                                    '<div class="fItem" ng-if="step === 3">' +
                                    '<img src="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" align="left" style="margin-right:7px;">' +
                                    '<tg-button button-class="button-blue" text="Temp - Skip Paypal" text-label-class="buttonLabel"></tg-button>' +
                                    '</div>',
                                controller: 'producerRegistrationController'
                            }
                        }
                    }
                },
                {
                    name: 'producer.stepone',
                    config: {
                        templateUrl: '/Authentication/Registration/Producer/Step1',
                        url: '/StepOne'
                    }
                },
                {
                    name: 'producer.steptwo',
                    config: {
                        templateUrl: '/Authentication/Registration/Producer/Step2',
                        url: '/StepTwo'
                    }
                },
                {
                    name: 'producer.stepthree',
                    config: {
                        templateUrl: '/Authentication/Registration/Producer/Step3',
                        url: '/StepThree'
                    }
                },
                {
                    name: 'viewer',
                    config: {
                        abstract: true,
                        views: {
                            'header': {
                                template: '<div>' +
                                    '<span ng-if = "viewerService.step === 1" class="largeLabel">SELECT AN ACCOUNT TYPE</span>' +
                                    '<span ng-if = "viewerService.isConfirmation()" class="fa fa-check-square-o"></span><span ng-if = "viewerService.step !== 1" class="largeLabel nudge-right-small">{{viewerService.headers[viewerService.step-1]}}</span>' +
                                    '</div>' +
                                    '<div ng-if="viewerService.step !== 1">' +
                                    '<span class="largeLabel">STEP {{viewerService.step}} OF 3</span>' +
                                    '</div>',
                                controller: 'viewerRegistrationController'
                            },
                            'mainContent': {
                                template: '<form name="form.viewerRegistration" ng-controller="wizardViewerController" class="small-font" novalidate><div ui-view></div></form>'
                            },
                            'footer': {
                                template: '<div class="fItem" ng-if="!viewerService.isConfirmation()">' +
                                    '<tg-button button-class="button-gray stretch" left-icon-class="fa fa-arrow-left" text="Previous" text-label-class="buttonLabel" on-click="previousStep()"></tg-button>' +
                                    '</div>' +
                                    '<div class="fItem" ng-if="!viewerService.isConfirmation()">' +
                                    '<tg-button button-class="button-blue stretch" right-icon-class="fa fa-arrow-right" text="Next" text-label-class="buttonLabel" on-click="submit()" action="ladda.register"></tg-button>' +
                                    '</div>' +
                                    '<div class="fItem" ng-if="step === 3">' +
                                    '<img src="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" align="left" style="margin-right:7px;">' +
                                    '<tg-button button-class="button-blue" text="Temp - Skip Paypal" text-label-class="buttonLabel"></tg-button>' +
                                    '</div>',
                                controller: 'viewerRegistrationController'
                            }
                        }
                    }
                },
                {
                    name: 'viewer.stepone',
                    config: {
                        templateUrl: '/Authentication/Registration/Viewer/Step1'
                    }
                },
                {
                    name: 'viewer.steptwo',
                    config: {
                        templateUrl: '/Authentication/Registration/Viewer/Single/Step2'
                    }
                },
                {
                    name: 'viewer.stepthree',
                    config: {
                        templateUrl: '/Authentication/Registration/Viewer/Single/Step3'
                    }
                },
                {
                    name: 'viewer.steptwocommercial',
                    config: {
                        templateUrl: '/Authentication/Registration/Viewer/Commercial/Step2'
                    }
                },
                {
                    name: 'viewer.stepthreecommercial',
                    config: {
                        templateUrl: '/Authentication/Registration/Viewer/Commercial/Step3'
                    }
                },
                {
                    name: 'viewer.stepfourcommercial',
                    config: {
                        templateUrl: '/Authentication/Registration/Viewer/Commercial/Step4'
                    }
                },
                {
                    name: 'viewer.stepfivecommercial',
                    config: {
                        templateUrl: '/Authentication/Registration/Viewer/Commercial/Step5'
                    }
                }
            ];
            return {
                routes: routes,
                $get: function () { return null; }
            };
        }
    ]);