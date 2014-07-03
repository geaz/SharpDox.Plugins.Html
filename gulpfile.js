var gulp = require('gulp');
var rimraf = require('gulp-rimraf');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var msbuild = require("gulp-msbuild");
var concatCss = require('gulp-concat-css');

gulp.task('clean', function(){
	return gulp.src('build', {read: false})
		.pipe(rimraf());
});

gulp.task('msbuild', function(){
	return gulp.src('src/SharpDox.Plugins.Html.sln')
        .pipe(msbuild({
            targets: ['Clean', 'Rebuild'],
			configuration: 'Release'
		}));
});

gulp.task('build-vs', ['clean', 'msbuild'], function(){
	gulp.src(	['src/bin/Release/MarkdownSharp.dll',
				'src/bin/Release/SharpDox.Plugins.Html.dll'])
		.pipe(gulp.dest('build'));
});

gulp.task('build-js', ['clean'], function(){
	gulp.src(	['assets/js/app/index.js',
				'assets/js/app/NavigationController.js'])
		.pipe(uglify())
		.pipe(concat('app.js'))
		.pipe(gulp.dest('build/assets/js'));
	
	gulp.src(	['assets/js/frame/iframe.js',
				'assets/js/frame/svg.js'])
		.pipe(uglify())
		.pipe(concat('frame.js'))
		.pipe(gulp.dest('build/assets/js'));
	
	gulp.src(	['assets/js/vendor/jquery.min.js',
				'assets/js/vendor/jquery.dropdown.min.js',
				'assets/js/vendor/jquery.hashchange.min.js',
				'assets/js/vendor/jquery.layout.min.js',
				'assets/js/vendor/jquery.mousewheel.min.js',
				'assets/js/vendor/jquery-ui.custom.min.js',
				'assets/js/vendor/jstree.js',
				'assets/js/vendor/jquery.panzoom.js',
				'assets/js/vendor/jquery.print.js',
				'assets/js/vendor/canvg.js',
				'assets/js/vendor/highlight.pack.js',
				'assets/js/vendor/modernizr.js',
				'assets/js/vendor/rgbcolor.js',
				'assets/js/vendor/StackBlur.js'])
		.pipe(uglify())
		.pipe(concat('vendor.js'))
		.pipe(gulp.dest('build/assets/js'));
		
	gulp.src(	['assets/js/vendor/jquery.min.js',
				'assets/js/vendor/jquery.dropdown.min.js',
				'assets/js/vendor/jquery.hashchange.min.js',
				'assets/js/vendor/jquery.layout.min.js',
				'assets/js/vendor/jquery.mousewheel.min.js',
				'assets/js/vendor/jquery-ui.custom.min.js',
				'assets/js/vendor/jstree.js',
				'assets/js/vendor/jquery.print.js'])
		.pipe(uglify())
		.pipe(concat('vendor.ie8.js'))
		.pipe(gulp.dest('build/assets/js'));
});

gulp.task('build-css', ['clean'], function(){
	gulp.src('assets/css/style.css')
		.pipe(concatCss('style.css'))
		.pipe(gulp.dest('build/assets/css'));
});

gulp.task('copy-assets', ['clean'], function(){
	gulp.src('assets/font/*')
		.pipe(gulp.dest('build/assets/font'));
		
	gulp.src('assets/images/**')
		.pipe(gulp.dest('build/assets/images'));
});

gulp.task('default', ['copy-assets', 'build-vs', 'build-js', 'build-css'], function() {});