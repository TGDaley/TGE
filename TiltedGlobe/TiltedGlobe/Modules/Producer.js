angular.module('Producer', ['tgCommon', 'ui.bootstrap.datetimepicker'])
.config(['$httpProvider',
function ($httpProvider) {
    $httpProvider.defaults.headers.common['X-Requested-With'] = 'AngularJS-Routing';
}])
.controller('ProducerCtrl', ['$scope', 'dataService','$q','$window','$rootScope','$timeout','settings','$filter',
    function ($scope, dataService, $q, $window, $rootScope, $timeout, settings, $filter) {
        $scope.page = 'shows';
        $scope.isWizard = false;
        $scope.awaitingChannels = 0;
        $scope.awaitingShows = 0;
        $scope.user = { firstName: '' };
        $scope.loaded = false;
        $scope.ngDateFormat = 'MM/dd/yy hh:mm a';
        $scope.data = { date: null };
        $scope.selectedShow = null;
        $scope.frame = {
            class: 'inline-modal-frame'
        };
        var initialize = function () {
            _.each($scope.channels, function(channel) {
                if (!channel.approved) $scope.awaitingChannels += 1;
            });
            _.each($scope.shows, function(show) {
                if (!show.approved) $scope.awaitingShows += 1;
            });
            $q.all({
                user: dataService.get('accounts/user', null, null),
                shows: dataService.get('show', null, null),
                genres: dataService.get('genre', null, null),
                showTypes: dataService.get('showType', null, null)
            }).then(function(data) {
                $rootScope.user = data.user;
                $scope.user = data.user;
                $scope.shows = data.shows;
                $scope.genres = data.genres;
                $scope.showTypes = data.showTypes;
                $scope.loaded = true;
                _.each($scope.shows, function(show) {
                    show.thumbNailLink = 'https://surge-tiltedglobe.s3.amazonaws.com/staging/' + $rootScope.user.awsAssetKey + '/' + show.showThumbNailAwsAssetKey;
                    show.playBillLink = 'https://surge-tiltedglobe.s3.amazonaws.com/staging/' + $rootScope.user.awsAssetKey + '/' + show.playBillAwsAssetKey;
                    show.genre = _.find($scope.genres, function (g) { return g.id === show.genreId; });
                    show.showType = _.find($scope.showTypes, function (s) { return s.id === show.genre.showTypeId; });
                    show.showDates = [show.showDate];
                    show.ticketsSold = 0;
                    show.ratingText = $filter('filter')(settings.ratings(), { id: show.ratings })[0].val;
                });
            });
        }
        $scope.signOut = function () {
            dataService.removeToken();
            //TODO: must fix crappy but ngstorage needs this to be sure token is removed
            $timeout(function() {
                $window.location.href = '/';
            }, 110);
        };

        $scope.channels = [
            {
                image: 'event_1.png',
                date: '7/23/15 3:00PM CST',
                title: 'Mr. Jones Concert Special',
                description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar tempor.  oin gravida dolor sit amet lacus accumsan oin gravida dolor sit amet lacus accumsan',
                approved: false
            }];

        
        $scope.event = 'event_2.png';

        $scope.tabs = {
            shows: [
                { name: 'Upcoming', selected: true },
                { name: 'Past Shows', selected: false }
            ],
            settings: [
                { name: 'General Info', selected: true }, 
                { name: 'Revenue', selected: false },
                { name: 'Payment Info', selected: false },
                { name: 'Billing History', selected: false }
            ]
        };

        $scope.showView = function (view, isWizard) {
            $scope.page = view;
            $scope.isWizard = isWizard;
        };
        initialize();

    }]);