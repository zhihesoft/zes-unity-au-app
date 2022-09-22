const { dest, watch, task } = require('gulp');
const browserify = require("browserify");
const source = require('vinyl-source-stream');
const sourcemaps = require('gulp-sourcemaps');
const tsify = require("tsify");
const uglify = require("gulp-uglify");
const buffer = require('vinyl-buffer');

function build() {

    return browserify({
        basedir: '.',
        standalone: "zes",
        debug: true,
        ignoreMissing: true,
        entries: ['./src'],
        extensions: ['.ts'],
        cache: {},
        packageCache: {}
    })
        .plugin(tsify)
        .bundle()
        .pipe(source('main.bytes'))
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(uglify({ "keep_fnames": "true" }))
        .pipe(sourcemaps.write("./"))
        .pipe(dest("out"));

    // return src(['dist/*.js', 'node_modules/**/*.js'])
    //     .pipe(concat("main.js"))
    //     .pipe(dest("./out/"));
}

function watchSource() {
    watch(["src/*.ts"], build);
}

exports.build = build;
exports.watch = watchSource;