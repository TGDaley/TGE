angular.module('tgCommon')
.directive('tgInfoTooltip',
['$sce',
    function ($sce) {
        return {
            restrict: 'EA',
            templateUrl: '/Common/tgInfoTooltip',
            replace: true,
            scope: {
                'content': '@'
            },
            link: function (scope, elem, attrs) {
                scope.trustedContent = $sce.trustAsHtml(scope.content);
                scope.toggleTip = function(display) {
                    $('#tip' + scope.$id).css('display',display);
                };
            }
        }
    }]);