var webpack = require('webpack');

var DedupePlugin = webpack.optimize.DedupePlugin;
var UglifyJsPlugin = webpack.optimize.UglifyJsPlugin;
var CommonsChunkPlugin = webpack.optimize.CommonsChunkPlugin;
var HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: {
        'vendor': './app/vendor.ts',
        'app': './app/main.ts'
    },
    output: {
        path: "./build",
        filename: "[name].[hash].js"
    },
    devtool: 'source-map',
    resolve: {
        extensions: ['', '.webpack.js', '.web.js', '.ts', '.tsx', '.js']
    },
    module: {
        loaders: [
            { test: /\.tsx?$/, loader: 'ts-loader' },
            { test: /\.css$/, loader: "style-loader!css-loader?-url" }
        ]
    },
    plugins: [
        new DedupePlugin(),
        new UglifyJsPlugin({
            beautify: false, //prod
            mangle: { screw_ie8 : true }, //prod
            compress: { screw_ie8: true }, //prod
            comments: false //prod
        }),
        new webpack.ProvidePlugin({
            jQuery: 'jquery',
            $: 'jquery',
            jquery: 'jquery',
            svgPanZoom: '../../../vendor/svg/svgPanZoom/svg-pan-zoom'
        }),
        new CommonsChunkPlugin("vendor", "vendor.[hash].js"),
        new HtmlWebpackPlugin({ template: './index.html' }),
    ]
};