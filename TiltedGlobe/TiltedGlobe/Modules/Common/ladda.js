angular.module('tgCommon')
.directive('ladda', ['$rootScope', '$timeout', function ($rootScope, $timeout) {
    return {
        restrict: 'A',
        link: function (scope, $this, attrs) {
            $timeout(function () {
                if (!attrs['data-style']) attrs.$set('data-style', 'expand-right');
                if (!attrs['data-size']) attrs.$set('data-size', 'm');
                $this.addClass('ladda-button');

                var ladda = Ladda.create($this[0]);

                scope.$watch(attrs.ladda, function (val) {
                    if (typeof val !== 'undefined') {
                        if (val) ladda.start();
                        else ladda.stop();
                    }
                });
            }, 0);
        }
    };
}]);