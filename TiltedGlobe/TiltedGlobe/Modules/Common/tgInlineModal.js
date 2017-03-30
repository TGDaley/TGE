angular.module('tgCommon')
.directive('tgInlineModal',
[
    function () {
        return {
            restrict: 'E',
            templateUrl: '/Common/tgInlineModal',
            transclude: true,
            scope: {
                frame: '='
            },
            link: function (scope, elem, attrs) {
                if (!scope.frame) {
                    scope.frame = {
                        class: 'inline-modal-frame'
                    };
                }
                if (!scope.frame.class ) {
                    scope.frame.class = 'inline-modal-frame';
                }
            }
        }
    }])

.directive('tgInlineModalContent',
[
    function () {
        return {
            restrict: 'E',
            templateUrl: '/Common/tgInlineModalContent',
            transclude: true

        }
    }])

.directive('tgInlineModalFooter',
[
    function () {
        return {
            restrict: 'E',
            templateUrl: '/Common/tgInlineModalFooter',
            transclude: true

        }
    }]);