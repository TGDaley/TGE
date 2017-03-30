angular.module('tgCommon')
.factory('fileSizer',
  ['uuid','$rootScope','dataService','$q',
function (uuid, $rootScope,dataService,$q) {

    var fileSizer = {
        size: function (file) { return size(file); }
    }
    var size = function(file) {
        var image = new Image();
        image.src = file;
        var maxHeight = 248;
        var maxWidth = 440;
        var percentDiff = image.height / maxHeight;
        var width = percentDiff * image.width;
        width = width > maxWidth ? maxWidth : width;
        return {
            width: width,
            height: maxHeight
        };
    }

    return fileSizer;
}]);
    
      