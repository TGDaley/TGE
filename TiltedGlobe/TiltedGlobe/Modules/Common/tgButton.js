angular.module('tgCommon', ['ngStorage', 'ui.bootstrap'])
    .directive('tgButton',
    [
        function() {
            return {
                restrict: 'EA',
                templateUrl: '/Common/tgButton',
                replace: true,
                scope: {
                    'text': '@',
                    'onClick': '&',
                    'buttonClass': '@',
                    'rightIconClass': '@',
                    'leftIconClass': '@',
                    'textLabelClass': '@',
                    'action': '=',
                    'plusSign': '='
                }

            }
        }
    ]);