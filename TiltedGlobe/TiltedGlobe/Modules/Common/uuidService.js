angular.module('tgCommon')
.factory('uuid',
        [
            function() {
                return function() {
                    return window.uuid.v4().toLowerCase().replace(/-/g, '');
                };
            }
        ]);