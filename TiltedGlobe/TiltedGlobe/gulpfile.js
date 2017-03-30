var gulp = require('gulp');
var config = require('./gulp.config')();
var inject = require('gulp-inject');

gulp.task('wiredep', function(){
	var options = config.getWiredepOptions();
	var wiredep = require('wiredep').stream;
	return gulp
		.src(config.index)
		.pipe(wiredep(options))
		.pipe(inject(gulp.src(config.js)))
		.pipe(gulp.dest(config.client));
});

gulp.task('build', function(){
	return gulp.src(config.thirdParty)
	.pipe(gulp.dest(config.build))
	
});