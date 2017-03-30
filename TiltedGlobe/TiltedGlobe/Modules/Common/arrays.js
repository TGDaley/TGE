angular.module('tgCommon')
.factory('arrays',
        [
            function() {

                var arrays = {
                    indexById: function (array, id) {
                        var index = -1;

                        // we could use 2 underscore functions to do this, but 
                        // then it would have to loop through twice as much
                        var exists = _.any(array, function (item) {
                            index++;
                            return item.id == id;
                        });

                        return exists ? index : -1;
                    },
                    appendOrUpdate: function(array, item) {
                        var index = arrays.indexById(array, item.id);

                        if (index !== -1) array[index] = angular.copy(item);
                        else array.push(angular.copy(item));
                    }
                }
                return arrays;
            }
        ]);