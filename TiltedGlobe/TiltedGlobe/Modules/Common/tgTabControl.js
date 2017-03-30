angular.module('tgCommon')
.directive('tgTabControl',
[
    function () {
        return {
            restrict: 'EA',
            templateUrl: '/Common/tgTabControl',
            replace: true,
            scope: {
                'tabs': '='
            },
            link: function (scope, elem, attrs) {
                scope.changeView = function (tab) {
                    _.each(scope.tabs, function (t) {
                        t.selected = t.name === tab.name;
                    });
                    
                };
            }
        }
    }]);