angular.module('Producer')
.directive('tgManageShow',
['settings',   
    function (settings) {
        return {
            restrict: 'EA',
            templateUrl: '/Producer/tgManageShow',
            replace: true,
            link: function (scope, elem, attrs) {

                scope.numSteps = 8;
                scope.stepTitles = [];
                scope.dateFormat = settings.dateFormat();
                scope.ngDateFormat = settings.ngDateFormat();
                scope.newShow = {
                    showDates: [new Date()],
                    viewerIssued: [],
                    ticketing: {
                        singleViewer: [
                            {
                                issued: null,
                                basePrice: null
                            }
                        ]
                    },
                    commercialRetailPrice: [],
                    commercialIssued: [],
                    note: [],
                    productionCost: [],
                    totalTickets: [],
                    description: '',
                    showType: null,
                    reservationFee: 0
                };
            }
        }
    }]);
angular.module('Producer')
    .controller('wizardController',
    [
        '$scope', 'dataService', 'arrays', 'newShow', 'view', 'closeModal','shows','showTypes','genres',
        function($scope, dataService, arrays, newShow, view, closeModal, shows, showTypes, genres) {

            $scope.newShow = newShow;
            $scope.view = view;
            $scope.step = 1;
            $scope.closeModal = closeModal;
            $scope.showTypes = showTypes;
            $scope.genres = genres;
            $scope.frame = {
                class: 'edit-show-wizard-frame-pricing'
            };
            $scope.relatedShows = _.filter(shows, function(show) {
                return (show.batchId === $scope.newShow.batchId
                        && show.id !== $scope.newShow.id
                );
            });
            $scope.shows = shows;
        }
    ]);

angular.module('Producer')
.controller('wizardFormController',
    ['$scope', 'dataService','arrays','uuid','fileUploader','$q','$rootScope','settings',
    function ($scope, dataService, arrays, uuid, fileUploader, $q, $rootScope, settings) {
        function isEmptyObject(obj) {
            for (var prop in obj) {
                if (Object.prototype.hasOwnProperty.call(obj, prop)) {
                    return false;
                }
            }
            return true;
        }
        var reservationFeeCalculation = function () {
            var durationsHours = Math.ceil(parseInt($scope.newShow.estimatedDuration) / 60);
            return (
                durationsHours
                    * $scope.pricingConfig.bandwidthUsedPerHourOfStreaming
                    * $scope.pricingConfig.costOfAgbOfBandwidth
                    + $scope.pricingConfig.liveIngestFee
                    + $scope.pricingConfig.dvrService
                    + $scope.pricingConfig.mediaPlayer
                    + $scope.pricingConfig.securityProtocol
                    + $scope.pricingConfig.registrationAdminfee);
        };
        var close = function() {
            $scope.closeModal();
        }
        var myShows = function () {
            $scope.showView('shows');
        };
        var previous = function () { $scope.navigate(-1); }
        var next = function () {
            $scope.navigate(1);
        }
        var save = function () {
            var batchId = uuid();
            var shows = [];
            _.each($scope.newShow.showDates, function (s, key) {
                shows.push({
                    showDate: $scope.newShow.showDates[key],
                    singleViewerTicketsIssued: $scope.newShow.ticketing.singleViewer[key].issued,
                    singleViewerBasePrice: $scope.newShow.ticketing.singleViewer[key].basePrice,
                    commercialViewerBasePrice: $scope.newShow.ticketing.commercialViewer[key] ? $scope.newShow.ticketing.commercialViewer[key].basePrice : 0,
                    commercialViewerTicketsIssued: $scope.newShow.ticketing.commercialViewer[key] ? $scope.newShow.ticketing.commercialViewer[key].issued : 0,
                    note: $scope.newShow.note[key],
                    name: $scope.newShow.name,
                    description: $scope.newShow.description,
                    approved: $scope.newShow.approved,
                    genreId: $scope.newShow.genre.id,
                    rating: $scope.newShow.rating,
                    estimatedDuration: $scope.newShow.estimatedDuration,
                    shouldConvertToOnDemand: $scope.newShow.shouldConvertToOnDemand,
                    isOwner: $scope.newShow.isOwner,
                    isDelayedViewingEnabled: $scope.newShow.isDelayedViewingEnabled,
                    allowCommercialViewersToStream: $scope.newShow.allowCommercialViewersToStream,
                    batchId: batchId,
                    royaltyAgreementAwsAssetKey: $scope.newShow.royaltyAgreementAwsAssetKey,
                    showThumbNailAwsAssetKey: $scope.newShow.showThumbNailAwsAssetKey,
                    venueContractAwsAssetKey: $scope.newShow.venueContractAwsAssetKey,
                    playBillAwsAssetKey: $scope.newShow.playBillAwsAssetKey,
                    applicationUserId: $rootScope.user.id
                });
            });
            dataService.upsert('show', shows)
                .then(function (response) {
                    next();
                    _.each(response, function (s) {
                        arrays.appendOrUpdate($scope.shows, s);
                    });
                },
                    function (data) {
                        //TODO: firgure out error handling maybe
                    });
        }
        var update = function() {
            var shows = [];
            $scope.newShow.genreId = $scope.newShow.genre.id;
            shows.push($scope.newShow);
            _.each($scope.relatedShows, function(show) {
                if (show.batchModify) {
                    shows.push({
                        id: show.id,
                        showDate: show.showDate,
                        singleViewerTicketsIssued: $scope.newShow.singleViewerTicketsIssued,
                        singleViewerBasePrice: $scope.newShow.singleViewerBasePrice,
                        commercialViewerBasePrice: $scope.newShow.commercialViewerBasePrice,
                        commercialViewerTicketsIssued: $scope.newShow.commercialViewerTicketsIssued,
                        note: $scope.newShow.note,
                        name: $scope.newShow.name,
                        description: $scope.newShow.description,
                        approved: $scope.newShow.approved,
                        genreId: $scope.newShow.genre.id,
                        rating: $scope.newShow.rating,
                        estimatedDuration: $scope.newShow.estimatedDuration,
                        shouldConvertToOnDemand: $scope.newShow.shouldConvertToOnDemand,
                        isOwner: $scope.newShow.isOwner,
                        isDelayedViewingEnabled: $scope.newShow.isDelayedViewingEnabled,
                        allowCommercialViewersToStream: $scope.newShow.allowCommercialViewersToStream,
                        batchId: $scope.newShow.batchId,
                        royaltyAgreementAwsAssetKey: $scope.newShow.RoyaltyAgreementAwsAssetKey,
                        showThumbNailAwsAssetKey: $scope.newShow.ShowThumbNailAwsAssetKey,
                        venueContractAwsAssetKey: $scope.newShow.VenueContractAwsAssetKey,
                        playBillAwsAssetKey: $scope.newShow.PlayBillAwsAssetKey,
                        applicationUserId: $rootScope.user.id
                    });
                }
            });
            dataService.upsert('show', shows)
                .then(function(response) {
                        next();
                        _.each(response, function(s) {
                            arrays.appendOrUpdate($scope.shows, s);
                        });
                    },
                    function(data) {
                        //TODO: firgure out error handling maybe
                    });
        }
        var uploadFile = function (fileObject, assetKey, mandatory) {
            var deferred = $q.defer();
            var uploads = {};
            if (!mandatory)mandatory = [];
            for (var i = 0; i < assetKey.length; i++) {
                if ($scope.newShow[assetKey[i]]) {
                    if ($scope.newShow[fileObject[i]]) {
                        uploads[i] = fileUploader.upload($scope.newShow[fileObject[i]], $scope.newShow[assetKey[i]]);
                    }
                } else if (mandatory[i]) {
                    deferred.reject();
                    return deferred.promise;
                }
            }
            if (isEmptyObject(uploads)) {
                deferred.resolve();
                return deferred.promise;
            }
            return $q.all(uploads);
        };
        $scope.ratings = settings.ratings();
        $scope.dateFormat = settings.dateFormat();
        if ($scope.view === 'editShow') {
            $scope.stepTitles = [
                {
                    id: 'editShowListing',
                    header: { name: 'Edit The Show Listing?' },
                    footer: {
                        previous: { text: 'Cancel', leftIconClass: 'fa fa-times-circle', buttonClass: 'button-gray stretch', onClick: close },
                        next: { text: 'Edit Listing', leftIconClass: 'fa fa-pencil-square-o', buttonClass: 'button-blue stretch', onClick: next }

                    }
                },
                {
                    id: 'editShowData',
                    header: { name: 'Edit Show Data' },
                    footer: {
                        previous: { text: 'Cancel', leftIconClass: 'fa fa-times-circle', buttonClass: 'button-gray stretch', onClick: close },
                        next: {
                            text: 'Update Listing',
                            leftIconClass: 'fa fa-check-square-o',
                            buttonClass: 'button-blue stretch',
                            onClick: function () {
                                uploadFile(['showThumbNail'], ['showThumbNailAwsAssetKey'], [true]).then(function () {
                                    if ($scope.relatedShows.length > 0) {
                                        next();
                                    } else {
                                        update();
                                        $scope.navigate(2);
                                    }
                                }, function () { $scope.showForm.$setSubmitted(); });
                            }
                        }
                    }
                },
                {
                    id: 'applytoall',
                    header: { name: 'Apply to All Recurrences?' },
                    footer: {
                        previous: { text: 'Previous', leftIconClass: 'fa fa-arrow-left', buttonClass: 'button-gray stretch', onClick: previous },
                        next: {
                            text: 'Next', rightIconClass: 'fa fa-arrow-right', buttonClass: 'button-blue stretch',
                            onClick: update
                        }
                    }
                },
                {
                    id: 'simpleText',
                    content: 'The changes to your show have been submitted to the admin for approval.  New changes will not be  viewable to the public until they are approved by Tilted Globe.',
                    header: { name: 'Changes Submitted', fontAwesomeClass: 'fa fa-check-square' },
                    footer: {
                        next: { text: 'Done', buttonClass: 'button-blue stretch', onClick: close }
                    }
                }
            ];
        } else {

            $scope.stepTitles = [
                {
                    id: 'createNewShow',
                    header: { name: 'Create New Show' },
                    footer: {
                        next: {
                            text: 'NEXT',
                            rightIconClass: 'fa fa-arrow-right',
                            buttonClass: 'button-blue stretch',
                            onClick: function() {
                                $scope.newShow.reservationFee = reservationFeeCalculation();
                                uploadFile(['playBill'], ['playBillAwsAssetKey']).then(function() { next(); });
                            }
                        }
                    }
                },
                {
                    id: 'createNewShow2',
                    header: { name: 'Create New Show' },
                    footer: {
                        previous: { text: 'Previous', leftIconClass: 'fa fa-arrow-left', buttonClass: 'button-gray stretch', onClick: previous },
                        next: { text: 'Next', rightIconClass: 'fa fa-arrow-right', buttonClass: 'button-blue stretch', onClick: next }
                    }
                },
                {
                    id: 'uploadForms',
                    header: { name: 'Upload Authorization Forms' },
                    footer: {
                        previous: { text: 'Previous', leftIconClass: 'fa fa-arrow-left', buttonClass: 'button-gray stretch', onClick: previous },
                        next: {
                            text: 'Next',
                            rightIconClass: 'fa fa-arrow-right',
                            buttonClass: 'button-blue stretch',
                            onClick: function() {
                                uploadFile(['theaterContract', 'royaltyAgreements'], ['theaterContractAwsAssetKey', 'royaltyAgreementsAwsAssetKey']).then(function() {
                                    next();
                                });
                            }
                        }
                    }
                },
                {
                    id: 'pricing',
                    header: { name: 'Create New Show' },
                    footer: {
                        previous: { text: 'Previous', leftIconClass: 'fa fa-arrow-left', buttonClass: 'button-gray stretch', onClick: previous },
                        next: {
                            text: 'PROCEED TO CHECKOUT',
                            rightIconClass: 'fa fa-arrow-right',
                            buttonClass: 'button-blue stretch',
                            onClick: function() {
                                uploadFile(['showThumbNail'], ['showThumbNailAwsAssetKey'], [true]).then(function() {
                                    if (
                                        _.uniq($scope.newShow.ticketing.singleViewer, function(item) { return item.basePrice; }).length <= 1
                                            && _.uniq($scope.newShow.ticketing.commercialViewer, function(item) { return item.basePrice; }).length <= 1) {
                                        $scope.navigate(2);
                                    } else {
                                        $scope.navigate(1);
                                    }
                                }, function() { $scope.showForm.$setSubmitted(); });
                            }
                        }
                    }
                },
                {
                    id: 'pricingOptional',
                    header: { name: 'Difference in Pricing (Optional)' },
                    footer: {
                        previous: { text: 'Previous', leftIconClass: 'fa fa-arrow-left', buttonClass: 'button-gray stretch', onClick: previous },
                        next: { text: 'Next', rightIconClass: 'fa fa-arrow-right', buttonClass: 'button-blue stretch', onClick: next }
                    }
                },
                {
                    id: 'confirm',
                    header: { name: 'Confirm Purchase' },
                    footer: {
                        previous: {
                            text: 'Previous',
                            leftIconClass: 'fa fa-arrow-left',
                            buttonClass: 'button-gray stretch',
                            onClick: function() {
                                if (
                                    _.uniq($scope.newShow.ticketing.singleViewer, function (item) { return item.basePrice; }).length <= 1
                                    && _.uniq($scope.newShow.ticketing.commercialViewer, function(item) { return item.basePrice; }).length <= 1) {
                                    $scope.navigate(-2);
                                } else {
                                    $scope.navigate(-1);
                                }
                            }
                        },
                        next: { text: 'Save', rightIconClass: 'fa fa-arrow-right', buttonClass: 'button-blue stretch', onClick: save }
                    }
                },
                {
                    id: 'simpleText',
                    content: 'Your payment has been accepted and your show listing has been created.  You will be notified once your show is approved.',
                    header: { name: 'Purchase Accepted' },
                    footer: {
                        next: { text: 'My Shows', leftIconClass: 'fa fa fa-video-camera', buttonClass: 'button-blue stretch', onClick: myShows }
                    }
                }
            ];
        }
        

        $scope.pageCnt = 0;
        
        $scope.page = $scope.stepTitles[$scope.pageCnt];
        $scope.navigate = function (step) {
            if (!$scope.showForm.$valid && step > 0) {
                $scope.showForm.$setSubmitted();
                return;
            }
            $scope.showForm.$setPristine();
            $scope.pageCnt += step;
            if ($scope.stepTitles[$scope.pageCnt]) {
                $scope.page = $scope.stepTitles[$scope.pageCnt];
                if ($scope.page.id === 'pricing') {
                    $scope.frame.class = 'add-show-wizard-frame-pricing';
                } else if ($scope.view === 'editShow') {
                    $scope.frame.class = 'edit-show-wizard-frame-pricing';
                } else {
                    $scope.frame.class = 'inline-modal-frame';
                }
            }
        };

        $scope.productionCharge = 0;

        $scope.productionChargeChange = function () {
            var singleViewerProfit = 0,
                commercialViewerProfit = 0,
                singleViewerProductionCost = 0,
                commercialViewerProductionCost = 0;
            _.each($scope.newShow.ticketing.singleViewer, function(item) {
                item.potentialEarnings = $scope.feeCalculator.potentialEarning(item.basePrice, item.issued);
                item.handlingFee = $scope.feeCalculator.handlingFee(item.basePrice, $scope.pricingConfig.saleAdminFeeForSingleViewer);
                item.retailPrice = $scope.feeCalculator.retailPrice(item.basePrice, $scope.pricingConfig.saleAdminFeeForSingleViewer);
                item.productionCost = parseInt(item.issued) * $scope.newShow.reservationFee;
                singleViewerProfit = singleViewerProfit + item.potentialEarnings;
                singleViewerProductionCost = singleViewerProductionCost + item.productionCost;
            });

            _.each($scope.newShow.ticketing.commercialViewer, function (item) {
                item.potentialEarnings = $scope.feeCalculator.potentialEarning(item.basePrice, item.issued);
                item.handlingFee = $scope.feeCalculator.handlingFee(item.basePrice, $scope.pricingConfig.saleAdminFeeForCommercialViewer);
                item.retailPrice = $scope.feeCalculator.retailPrice(item.basePrice, $scope.pricingConfig.saleAdminFeeForCommercialViewer);
                item.productionCost = parseInt(item.issued) * $scope.newShow.reservationFee;
                commercialViewerProfit = commercialViewerProfit + item.potentialEarnings;
                commercialViewerProductionCost = commercialViewerProductionCost + item.productionCost;
            });
            $scope.newShow.grossPotentialEarnings = singleViewerProfit + commercialViewerProfit;
            $scope.newShow.totalProductionCost = singleViewerProductionCost + commercialViewerProductionCost;
            $scope.newShow.potentialNetProfit = $scope.newShow.grossPotentialEarnings - $scope.newShow.totalProductionCost;
        };

        $scope.totalTicketsIssued = function(ticketing, index) {
            return ticketing.commercialViewer ?
                parseInt(ticketing.singleViewer[index].issued) + parseInt(ticketing.commercialViewer[index].issued)
                : parseInt(ticketing.singleViewer[index].issued);
        };

        $scope.addShowDate = function () {
            $scope.newShow.showDates.push(new Date());
        };

        $scope.removeDate = function (index) {
            $scope.newShow.showDates.splice(index, 1);
        };

        $scope.isDirty = function(item, index) {
            return $scope.showForm[item + index] ? $scope.showForm[item + index].$dirty : false;
        };

        $scope.areFieldsDirtyAndInvalid = function () {
            var retval = false;
            _.each($scope.newShow.showDates, function(key, index) {
                if (($scope.isDirty('singleViewerPricing', index) && !$scope.newShow.ticketing.singleViewer[index].issued)
                    || ($scope.isDirty('singleViewerIssued', index) && !$scope.newShow.ticketing.singleViewer[index].basePrice)
                    || (($scope.isDirty('commercialViewerPricing', index) || $scope.isDirty('commercialViewerIssued', index)) && !$scope.newShow.ticketing.commercialViewer)
                    || ($scope.isDirty('commercialViewerPricing', index) && !$scope.newShow.ticketing.commercialViewer[index].issued)
                    || ($scope.isDirty('commercialViewerIssued', index) && !$scope.newShow.ticketing.commercialViewer[index].basePrice)) {
                    retval = true;
                }
            });
            return retval;
        };

        $scope.beforeRender = function($view, $dates, $leftDate, $upDate, $rightDate) {
            var minDate = new Date().getTime();
            for (d in $dates) {
                if ($dates[d].utcDateValue < minDate) {
                    $dates[d].selectable = false;
                }
            };
        }

        $scope.removeThumbNail = function() {
            $scope.newShow.showThumbNail = null;
            $scope.newShow.showThumbNailAwsAssetKey = null;
        }

        $scope.feeCalculator = {
            handlingFee: function (basePrice, fee) {
                return parseFloat(basePrice) * fee;
            },
            retailPrice: function (basePrice, fee) {
                return parseFloat(basePrice) + this.handlingFee(basePrice, fee);
            },
            potentialEarning: function (basePrice, ticketsIssued) {
                return parseInt(ticketsIssued) * parseFloat(basePrice);
            }
        };
        $scope.pricingConfig = {
            costOfAgbOfBandwidth: .06,
            bandwidthUsedPerHourOfStreaming: 32.4,
            liveIngestFee: .14,
            dvrService: .1,
            mediaPlayer: .3,
            securityProtocol: .1,
            registrationAdminfee: 2,
            saleAdminFeeForCommercialViewer: .15,
            saleAdminFeeForSingleViewer: .15
        };
    }
    ]);

