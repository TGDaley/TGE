angular.module('tgCommon')
.directive('showListing',
['$modal','$window','settings',
    function ($modal, $window, settings) {
        return {
            restrict: 'EA',
            templateUrl: '/Common/tgShowListing',
            replace: true,
            scope: {
                'showList': '=',
                'selectedShow': '=',
                'genres': '=',
                'showTypes': '='
            },
            link: function (scope, elem, attrs) {
                var modalInstance;
                scope.player = {};
                scope.edit = function(view) {
                    var closeModal = function() { modalInstance.dismiss(); }
                    scope.view = view;
                    modalInstance = $modal.open({
                        animation: scope.animationsEnabled,
                        templateUrl: '/Producer/tgManageShow',
                        controller: 'wizardController',
                        size: 'sm',
                        resolve: {
                            newShow: function() {
                                return scope.selectedShow;
                            },
                            genres: function () {
                                return scope.genres;
                            },
                            showTypes: function () {
                                return scope.showTypes;
                            },
                            view: function() {
                                return scope.view;
                            },
                            closeModal: function() {
                                return closeModal;
                            },
                            shows: function () {
                                return scope.showList;
                            },
                            
                        },
                        backdrop: 'static'
                    });

                    modalInstance.result.then(function(selectedItem) {
                        scope.selected = selectedItem;
                    }, function () {
                        //modal dismissed
                    });
                };
                scope.changeShowListingView = function (show) {
                    if (show) {
                        scope.selectedShow = show;
                    } else {
                        scope.selectedShow = null;
                    }
                };
                scope.viewPlayBill = function () {
                    $window.open(scope.selectedShow.playBillLink, '_blank');
                };
                scope.goLive = function() {
                    scope.player.start();
                };
                scope.ratings = settings.ratings();
            }
        }
}]);

