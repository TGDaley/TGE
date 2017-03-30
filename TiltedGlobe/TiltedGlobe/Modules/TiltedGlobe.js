angular.module('TiltedGlobe', ['ui.router', 'countrySelect', 'reCAPTCHA', 'tgCommon'])
    .config([
        '$httpProvider',
        '$provide',
        '$locationProvider',
        '$stateProvider',
        'reCAPTCHAProvider',
        '$urlRouterProvider',
        'authenticationRouteProvider',
        function($httpProvider, $provide, $locationProvider, $stateProvider, reCAPTCHAProvider, $urlRouterProvider, authenticationRouteProvider) {
            $httpProvider.defaults.headers.common['X-Requested-With'] = 'AngularJS-Routing';
            $locationProvider.hashPrefix('!').html5Mode(true);

            $httpProvider.interceptors.push(AuthHttpResponseInterceptor);
            $httpProvider.interceptors.push(AuthHttpResponseErrorInterceptor);

            reCAPTCHAProvider.setPublicKey('6LcWbQUTAAAAAM4bt6Dz87xShILmnkN75dNGPwkN');
            reCAPTCHAProvider.setOptions({
                theme: 'custom',
                custom_theme_widget: 'recaptcha_widget'
            });


            $provide.decorator(
                '$templateRequest',
                function($delegate) {
                    var mySilentProvider = function(tpl, ignoreRequestError) {
                        return $delegate(tpl, true);
                    }

                    return mySilentProvider;
                });

            _.each(authenticationRouteProvider.routes, function(route) {
                $stateProvider.state(route.name, route.config);
            });

            $urlRouterProvider.otherwise('/');
        }
    ])

    .run(['$state', function ($state) {
    // Include $route to kick start the router.
}]);