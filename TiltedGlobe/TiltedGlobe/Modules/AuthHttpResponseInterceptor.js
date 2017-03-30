var AuthHttpResponseInterceptor = function ($q) {
    return {
        response: function(response) {
            if (response.status === 401) {
                //console.log("Response 401");
            }
            return response || $q.when(response);
        }
    };
}

AuthHttpResponseInterceptor.$inject = ['$q'];



var AuthHttpResponseErrorInterceptor = function ($q, $location, $injector) {
    return {
        responseError: function(rejection) {

            //attempt to access page for logged-in only, redirect
            if (rejection.status === 401) {
                $injector.get('$state').go('login', { returnUrl: $location.path() });
            }

            //rejection - used in registration if a user tries to register with an existing email address
            if (rejection.status === 409) {
                //TODO
            }

            return $q.reject(rejection);
        }
    };
}

AuthHttpResponseErrorInterceptor.$inject = ['$q', '$location', '$injector'];
