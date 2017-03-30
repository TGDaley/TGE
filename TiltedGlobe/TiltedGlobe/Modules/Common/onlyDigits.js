angular.module('tgCommon')
.directive('onlyNumeric', function () {
    return {
        restrict: 'A',
        require: '?ngModel',
        link: function (scope, element, attrs, ngModel) {
            if (!ngModel) return;
            var allowDecimal = attrs.hasOwnProperty('allowDecimal');
            var allowZero = attrs.hasOwnProperty('allowZero');
            var validate = function (inputValue) {
                var firstDecimalFound = false;
                var digits = inputValue.split('').filter(function(s) {
                    if (s === '.' && !firstDecimalFound && allowDecimal) {
                        firstDecimalFound = true;
                        return true;
                    }   
                    if (
                        !isNaN(s)
                        && s !== ' '
                        && (allowZero || (inputValue.length === 1 && parseInt(s) !== 0) || (inputValue.length > 1)))
                        return true;
                    return false;
                }).join('');
                ngModel.$setViewValue(digits);
                ngModel.$render();
                return digits;
            };
            ngModel.$parsers.unshift(validate);
        }
    };
});