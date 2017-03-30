angular.module('tgCommon')
    .directive('amp',
    [
        function() {
            return {
                restrict: 'EA',
                templateUrl: '/Common/amp',
                replace: true,
                scope: {
                    'player': '=',
                },
                link: function(scope, element, attrs) {
                    scope.player.start = function () {
                        var amp;
                        function loadHandler() {
                            var config = {
                                autoplay: true,
                                volumepanel: {
                                    direction: "vertical"
                                },
                                media: {
                                    title: "VOD Sample",
                                    poster: '../amp/resources/images/hd_world.jpg',
                                    duration: 108,
                                    source: [{
                                        src: 'http://tiltedg-lh.akamaihd-staging.net/z/test1_5@348236/manifest.f4m',
                                        type: "video/f4m"
                                    }, {
                                        src: "http://tiltedg-lh.akamaihd-staging.net/z/test1_5@348236/master.m3u8",
                                        type: "application/x-mpegURL"
                                    }]
                                }
                            };
                            //tiltedg-loadHandler.akamaihd-staging.networkState/z/test1_1@348236/manifest.f4m
                            akamai.amp.AMP.loadDefaults("/amp/samples.js", function () {
                                amp = akamai.amp.AMP.create("akamai-media-player", config);
                            });
                        };

                        loadHandler();
                    };
                }

            }
        }
    ]);