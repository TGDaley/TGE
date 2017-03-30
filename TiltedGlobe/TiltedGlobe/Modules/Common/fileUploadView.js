'use strict';

angular.module('tgCommon')

.directive('fileUploadView', ['uuid', 'fileSizer', function (uuid, fileSizer) {
    return {
        restrict: 'A',
        scope: {
            file: '=',
            fileUrl:'@'
        },
        link: function (scope, element, attrs) {
            var loadFile = function(file) {
                var reader = new FileReader();
                reader.onload = function(e) {
                    element.css('background', 'transparent url(' + e.target.result + ') no-repeat center center');
                    var imageSize = fileSizer.size(e.target.result);
                    element.css({ 'background-size': imageSize.width + "px " + imageSize.height + "px" });
                    scope.$apply();
                }
                reader.readAsDataURL(file);
            };

            scope.$watch('file',
              function (newVal, oldVal) {
                  if (scope.file) {
                      loadFile(scope.file);
                  } else if (newVal !== oldVal) {
                      element.css('background', '');
                  }
              });
            if (scope.fileUrl) {
                element.css('background', 'transparent url(' + scope.fileUrl + ') no-repeat center center');
                var size = fileSizer.size(scope.fileUrl);
                element.css({ 'background-size': size.width + "px " + size.height + "px" });
                scope.fileUrl = null;
            }
        }
    };
}]);