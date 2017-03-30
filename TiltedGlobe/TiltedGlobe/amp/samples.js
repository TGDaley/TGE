{
	"paths": {
		"player": "amp/",
		"resources": "resources/"
	},
	"resources": [
		{
			"src": "#{paths.player}amp.css",
			"type": "text/css"
		}
	],
	"controls": {
		"enabled": true
	},
	"fullscreen": {
		"native": true,
		"enabled": true
	},
	"playoverlay": {
		"enabled": true
	},
	"branding": {
		"logo": "#{paths.resources}images/akamai_logo1.png"
	},
	"captioning": {},
	"flash": {
		"swf": "#{paths.player}AkamaiStandardPlayer.swf",
		"debug": "#{paths.player}AkamaiStandardPlayer-debug.swf",
		"expressInstallSWF": "#{paths.player}playerProductInstall.swf",
		"static": {
			"enabled": false,
			"swf": "#{paths.player}AkamaiStandardPlayer-static.swf",
			"debug": "#{paths.player}AkamaiStandardPlayer-debug.swf",
			"plugins": [
				{
					"src": "com.akamai.osmf.AkamaiAdvancedStreamingPluginInfo",
					"host": "osmf",
					"id": "AkamaiAdvancedStreamingPlugin",
					"type": "static"
				},
				{
					"src": "com.akamai.playeranalytics.osmf.OSMFCSMALoaderInfo",
					"host": "osmf",
					"id": "OSMFCSMALoader",
					"type": "static"
				},
				{
					"src": "org.osmf.captioning.CaptioningPluginInfo",
					"host": "osmf",
					"id": "CaptioningPlugin",
					"type": "static"
				},
				{
					"src": "com.octoshape.osmf.streamingplugin.OctoshapeStreamingPluginInfo",
					"host": "osmf",
					"id": "OctoShapeStreamingPlugin",
					"type": "static"
				},
				{
					"src": "com.akamai.osmf.plugins.ccDecoder.OSMFCCDecoderPluginInfo",
					"host": "osmf",
					"id": "OSMFCCDecoderPlugin",
					"type": "static"
				},
				{
					"src": "VideoMetricsViewPlugin",
					"blocking": "false",
					"host": "akamai",
					"id": "VideoMetricsViewPlugin",
					"type": "static"
				},
				{
					"src": "VideoStatsInfoOverlayPlugin",
					"blocking": "false",
					"host": "akamai",
					"id": "VideoStatsInfoOverlayPlugin",
					"type": "static"
				}
			]
		},
		"xml": "<?xml version=\"1.0\" encoding=\"UTF-8\"?><application><player auto_play=\"false\" auto_replay=\"true\" dvr_enabled=\"1\" enable_alternate_server_mapping=\"true\" enable_end_user_mapping=\"true\" eventmanagementstates_enabled=\"false\" eventmanagementstates_status_interval=\"5\" eventmanagementstates_status_url=\"../resources/eventmanagement/playerstate.txt\" font_size=\"18\" hds_live_low_latency=\"false\" is_token_required=\"false\" locale_setting=\"en\" media_analytics_logging_enabled=\"false\" rewind_interval=\"15\" set_resume_dvr_at_live=\"true\" start_bitrate_index=\"-1\" title=\"Video Title\" use_netsession_client=\"true\" video_url=\"http://multiplatform-f.akamaihd.net/z/multi/april11/hdworld/hdworld_,512x288_450_b,640x360_700_b,768x432_1000_b,1024x576_1400_m,1280x720_1900_m,1280x720_2500_m,1280x720_3500_m,.mp4.csmil/manifest.f4m\" volume=\"50\"></player><view skin=\"../amp/standard.assets.swf\">    <element id=\"infoOverlay\" style=\"top: 0px; text-align: left;\"></element>    <element id=\"captionDisplay\" initState=\"cookie|off\" position=\"relative\" settingsEnabled=\"true\" style=\"bottom: 0px; windowColor:0x000000; windowOpacity:0; font:Arial; fontColor:0xffffff; fontOpacity:1; fontBGColor:0x000000; fontBGOpacity:0; edgeType:none; edgeColor:0x000000; edgeOpacity:1; scroll:None; fontSize:12;\"></element>    <element autoHide=\"5\" height=\"25\" id=\"controls\" itemMargin=\"5\" visible=\"true\"><element id=\"replayBtn\"></element>    <element id=\"playPauseBtn\"></element>    <element id=\"rewindBtn\"></element>    <element color=\"#FF0000\" id=\"progressBar\"></element>    <element color=\"#00FF00\" id=\"loadedBar\"></element>    <element id=\"scrubber\"></element>    <element id=\"captionBtn\"></element>    <element id=\"statsBtn\"></element>    <element id=\"hdclientBtn\"></element>    <element color=\"#0000FF\" id=\"volumeBar\"></element>    <element id=\"volumeBtn\"></element><element id=\"fullscreenBtn\"></element><element id=\"logo\" style=\"width: 205px; height: 60px; right: 15px; top: 15px; opacity: 1.0;\"></element><element id=\"liveIndicator\"></element><element id=\"streamTimeIndicator\">    <element id=\"streamTime\"></element>    <element id=\"streamDuration\"></element></element><element color=\"#FFFFFF\" id=\"timeLocationIndicator\" type=\"arrow\"></element><element id=\"goLiveBtn\"></element>    </element><element id=\"replayView\"></element>    </view></application>",
		"plugins": [
			{
				"src": "http://players.edgesuite.net/flash/plugins/osmf/advanced-streaming-plugin/v3.6/osmf2.0/AkamaiAdvancedStreamingPlugin.swf",
				"absolute": "true",
				"host": "osmf",
				"id": "AkamaiAdvancedStreamingPlugin",
				"type": "dynamic"
			},
			{
				"src": "com.akamai.playeranalytics.osmf.OSMFCSMALoaderInfo",
				"host": "osmf",
				"id": "OSMFCSMALoader",
				"type": "static"
			},
			{
				"src": "#{paths.resources}plugins/CaptioningPlugin.swf",
				"host": "osmf",
				"id": "CaptioningPlugin",
				"type": "dynamic"
			},
			{
				"src": "#{paths.resources}plugins/infinitehd-osmf-plugin-1507070@v329-OSMF_1_6_MA.swf",
				"host": "osmf",
				"id": "OctoShapeStreamingPlugin",
				"type": "dynamic"
			},
			{
				"src": "#{paths.resources}plugins/onCaptionInfoPlugin.swf",
				"host": "osmf",
				"id": "OSMFCCDecoderPlugin",
				"type": "dynamic"
			},
			{
				"src": "#{paths.resources}plugins/VideoMetricsViewPlugin.swf",
				"blocking": "false",
				"host": "akamai",
				"id": "VideoMetricsViewPlugin",
				"type": "dynamic"
			},
			{
				"src": "#{paths.resources}plugins/VideoStatsInfoOverlayPlugin.swf",
				"blocking": "false",
				"host": "akamai",
				"id": "VideoStatsInfoOverlayPlugin",
				"type": "dynamic"
			}
		]
	},
	"mediaanalytics": {
		"resources": [
			{
				"type": "text/javascript",
				"src": "http://79423.analytics.edgesuite.net/html5/akamaihtml5-min.js"
			}
		],
		"plugin": {
			"swf": "http://79423.analytics.edgesuite.net/csma/plugin/csma.swf"
		},
		"config": "http://ma188-r.analytics.edgesuite.net/config/beacon-2114.xml?setVideoObject=1",
		"dimensions": {
			"eventName": "AMP Sample Event",
			"title": "AMP Sample Title",
			"playerId": "#{player.mode} Player"
		}
	},
	"locales": {
		"en": {
			"MSG_EMAIL_TO": "To",
			"MSG_EMAIL_FROM": "From",
			"MSG_EMAIL_VIDEO": "Email this video",
			"MSG_EMAIL_MESSAGE_DEFAULT": "Check out this video from xxx",
			"MSG_EMAIL_MESSAGE": "Message",
			"MSG_EMAIL_ADDRESS_INVALID": "Invalid Email Address",
			"MSG_EMAIL_MESSAGE_INVALID": "Please limit your message to 500 characters or less.",
			"MSG_EMAIL_CHARACTERS_REMAINING_TEXT": " characters left",
			"MSG_EMAIL_SEND_FAILURE": "Message could not be sent.",
			"MSG_EMAIL_SEND_SUCCESS_MESSAGE": "Your email has been sent!",
			"MSG_SHARE_VIDEO_TEXT": "Share this video...",
			"MSG_POST_TEXT": "Post",
			"MSG_EMBED_TEXT": "Embed",
			"MSG_LINK_TEXT": "Link",
			"MSG_SHARE_CONNECT_FAILURE": "Unable to connect. Please try again.",
			"MSG_SHARE_CONTENT_DISABLED": "Share and embed are disabled.",
			"MSG_VERSION_TEXT": "Version",
			"MSG_BUFFERING_TEXT": "buffering",
			"MSG_CUSTOMIZE_CLIP_POINTS": "Customize the start and end point of the video.",
			"MSG_PAUSE": "Pause",
			"MSG_PREVIEW": "Preview",
			"MSG_CURRENT": "Currrent",
			"MSG_SEEK_TO": "Seek to",
			"MSG_LIVE": "LIVE",
			"MSG_DEFAULT_ERROR_MESSAGE": "Sorry, we were unable to play the media you selected. Please try again, or select alternate media.",
			"MSG_ERROR_PREFIX": "Error encountered: ",
			"MSG_STREAM_NOT_FOUND": "Stream not found",
			"MSG_CURRENT_WORKING_BANDWIDTH": "Current working bandwidth",
			"MSG_CURRENT_BITRATE_PLAYING": "Current bitrate playing",
			"MSG_MAX_BITRATE_AVAILABLE": "Max bitrate available",
			"MSG_NOT_AVAILABLE": "Not Available",
			"MSG_GO_LIVE": "GO LIVE",
			"MSG_REPLAY": "Replay",
			"MSG_NEXT_VIDEO": "Next video starts in: ",
			"MSG_RECOMMENDED": "Recommended",
			"MSG_VIEW_ALL": "View all ",
			"MSG_VIDEO": " videos",
			"MSG_CC": "CC",
			"MSG_CC_TITLE": "Captions",
			"MSG_CC_LANGUAGE": "Track :",
			"MSG_CC_PRESETS": "Presets :",
			"MSG_CC_FONT": "Font :",
			"MSG_CC_EDGE": "Edge :",
			"MSG_CC_SIZE": "Size :",
			"MSG_CC_SCROLL": "Scroll :",
			"MSG_CC_COLOR": "Color :",
			"MSG_CC_BACKGROUND": "Background :",
			"MSG_CC_WINDOW": "Window :",
			"MSG_CC_OPACITY": "Opacity :",
			"MSG_CC_SHOW_ADVANCED": "Show Advanced Settings",
			"MSG_CC_HIDE_ADVANCED": "Hide Advanced Settings",
			"MSG_CC_RESET": "Default",
			"MSG_CC_CANCEL": "Cancel",
			"MSG_CC_APPLY": "Apply",
			"MSG_EN": "English",
			"MSG_ES": "Spanish",
			"MSG_DE": "German",
			"MSG_FR": "French",
			"MSG_IT": "Italian",
			"MSG_RU": "Russian",
			"MSG_ZH": "Chinese",
			"MSG_CHROMECAST_MESSAGE": "Video playing on another screen"
		},
		"es": {
			"MSG_EMAIL_TO": "a",
			"MSG_EMAIL_FROM": "de",
			"MSG_EMAIL_VIDEO": "Enviar este vídeo",
			"MSG_EMAIL_MESSAGE_DEFAULT": "Echa un vistazo a este video de xxx",
			"MSG_EMAIL_MESSAGE": "mensaje",
			"MSG_EMAIL_ADDRESS_INVALID": "Dirección de correo electrónico no válida",
			"MSG_EMAIL_MESSAGE_INVALID": "Por favor limite su mensaje a 500 caracteres o menos.",
			"MSG_EMAIL_CHARACTERS_REMAINING_TEXT": "personajes de la izquierda",
			"MSG_EMAIL_SEND_FAILURE": "El mensaje no pudo ser enviado.",
			"MSG_EMAIL_SEND_SUCCESS_MESSAGE": "Tu email ha sido enviado!",
			"MSG_SHARE_VIDEO_TEXT": "Comparte este vídeo...",
			"MSG_POST_TEXT": "enviar",
			"MSG_EMBED_TEXT": "incrustar",
			"MSG_LINK_TEXT": "enlace",
			"MSG_SHARE_CONNECT_FAILURE": "No se puede conectar. Por favor, inténtelo de nuevo.",
			"MSG_SHARE_CONTENT_DISABLED": "Compartir e incrustar están desactivados.",
			"MSG_VERSION_TEXT": "versión",
			"MSG_BUFFERING_TEXT": "el almacenamiento en búfer",
			"MSG_CUSTOMIZE_CLIP_POINTS": "Personalizar el inicio y el punto final del video.",
			"MSG_PAUSE": "romper",
			"MSG_PREVIEW": "vista previa",
			"MSG_CURRENT": "corriente",
			"MSG_SEEK_TO": "Tratar de",
			"MSG_LIVE": "EN VIVO",
			"MSG_DEFAULT_ERROR_MESSAGE": "Lo sentimos, no hemos podido jugar los medios de comunicación seleccionados. Por favor, inténtelo de nuevo, o seleccionar los medios de comunicación alternativos.",
			"MSG_ERROR_PREFIX": "Se produjo un error: ",
			"MSG_STREAM_NOT_FOUND": "Stream que no se encuentra",
			"MSG_CURRENT_WORKING_BANDWIDTH": "Ancho de banda actual de trabajo",
			"MSG_CURRENT_BITRATE_PLAYING": "Tasa de bits de reproducción actual",
			"MSG_MAX_BITRATE_AVAILABLE": "Tasa de bits máxima disponible",
			"MSG_NOT_AVAILABLE": "No está disponible",
			"MSG_GO_LIVE": "IR A VIVIR",
			"MSG_REPLAY": "Repetir",
			"MSG_NEXT_VIDEO": "El próximo video comienza en: ",
			"MSG_RECOMMENDED": "Recomendado",
			"MSG_VIEW_ALL": "Ver todos ",
			"MSG_VIDEO": " vídeos",
			"MSG_CC": "CC",
			"MSG_CHROMECAST_MESSAGE": "Video playing on another screen",
			"MSG_ZH": "Chino"
		}
	}
}