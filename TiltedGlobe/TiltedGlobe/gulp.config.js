module.exports = function() {
	
	var config = {
		build: './build/',
		client: 'Scripts/',
		index: 'Views/Home/index.cshtml',
		js: ['Scripts/Controllers/ProducerRegistrationController.js'],
		bower: {
			json: require('./bower.json'),
			directory: './bower_components',
			ignorePath: '../..',
			 devDependencies: true
		},
		thirdParty: ['./bower_components/angular/angular.js']
	};	
	config.getWiredepOptions = function() {
		var options = {
			bowerJson: config.bower.json,
			directory: config.bower.directory,
			ignorePath: config.bower.ignorePath	
		};
		return options;
	};
	return config;
};