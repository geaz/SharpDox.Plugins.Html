var webpack = require('webpack');

var UglifyJsPlugin = webpack.optimize.UglifyJsPlugin;
var CommonsChunkPlugin = webpack.optimize.CommonsChunkPlugin;
var HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: {
        'vendor': './app/vendor.ts',
        'app': './app/app.ts'
    },
    output: {
        path: "./build",
        filename: "[name].[hash].js"
    },
    devtool: 'source-map',
    resolve: {
        extensions: ['', '.webpack.js', '.web.js', '.ts', '.tsx', '.js']
    },
    plugins: [
        new UglifyJsPlugin({
            sourceMap: true,
            minimize: true,
            mangle: {
                except: ['$super', '$', 'exports', 'require']
            }
        }),
        new CommonsChunkPlugin("vendor", "vendor.[hash].js"),
        new HtmlWebpackPlugin({ template: './index.html' }),
    ],
    module: {
        loaders: [
            { test: /\.tsx?$/, loader: 'ts-loader' }
        ]
    }
};