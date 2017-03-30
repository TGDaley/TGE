angular.module('tgCommon')
.factory('fileUploader',
  ['uuid','$rootScope','dataService','$q',
function (uuid, $rootScope,dataService,$q) {

    var fileUploader = {
        upload: function (file, assetKey) { return postToAwsS3(file, assetKey); }
    }
    var postToAwsS3 = function (file, assetKey) {
        var awsKey = 'staging/' + $rootScope.user.awsAssetKey + '/' + assetKey;
        var deferred = $q.defer();
        dataService.get('aws', { 'awsKey': awsKey }, null)
            .then(function(response) {
                var uploadComplete = function () { deferred.resolve(); };
                var uploadFailed = function() { deferred.reject(); };
                var fd = new FormData();
                fd.append('key', awsKey);
                fd.append('acl', 'public-read');
                fd.append('success_action_status', '201');
                fd.append('Content-Type', file.type);
                fd.append('AWSAccessKeyId', 'AKIAJQBEOTB5PFJW2QUA');
                fd.append('policy', response.policy);
                fd.append('signature', response.signature);
                fd.append('file', file);
                var xhr = new XMLHttpRequest();
                xhr.addEventListener("load", uploadComplete, false);
                xhr.addEventListener("error", uploadFailed, false);
                xhr.open('POST', 'https://surge-tiltedglobe.s3.amazonaws.com/', true);
                xhr.send(fd);
            });
        return deferred.promise;
    }

    return fileUploader;
}]);
    
      