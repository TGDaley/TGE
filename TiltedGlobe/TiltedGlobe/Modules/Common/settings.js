angular.module('tgCommon')
.factory('settings',
        [
function () {
    //moments translation is different than angulars these need 
    //to be unified using moments - making the moment format into
    //a filter
    var settings = {
        dateFormat: function() { return 'MM/DD/YY hh:mm a'; },
        ngDateFormat: function () { return 'MM/dd/yy hh:mm a'; },
        ratings : function() {
            return [
                { id: 1, val: 'Y' },
                { id: 2, val: 'Y7' },
                { id: 3, val: 'G' },
                { id: 4, val: 'PG' },
                { id: 5, val: '14' },
                { id: 6, val: 'MA' }
            ];
        }
    };

    return settings;
}]);