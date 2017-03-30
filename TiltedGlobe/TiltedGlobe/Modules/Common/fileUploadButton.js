'use strict';

angular.module('tgCommon')

.directive('fileUploadButton', ['uuid', '$timeout', function (uuid, $timeout) {
    return {
        restrict: 'AE',
        templateUrl: '/Common/fileUploadButton',
        scope: {
            file: '=',
            binding: '=',
            text: '@',
            showAdd: '@',
            accept:'@'
        },
        link: function (scope, element, attrs) {
            var el = element.find('input');
            if (scope.accept === 'images') {
                scope.fileTypes = '.jpg,.jpeg,.png';
            } else {
                scope.fileTypes = '.pdf,.doc,.docx,.jpg,.jpeg,.png';
            }
            el.bind('change', function (event) {
                var files = event.target.files;
                var file = files[0];
                if (scope.fileTypes.indexOf(file.name.substr(file.name.lastIndexOf(".") + 1)) > -1) {
                    scope.file = file;
                    scope.binding = uuid();
                    scope.$apply();
                }

            });

            scope.uploadItem = function () {
                $timeout(function () {
                    el.trigger("click");
                });
            }

        }
    };
}]);