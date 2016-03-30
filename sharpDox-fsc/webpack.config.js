var webpack = require('webpack');

module.exports = {
    entry: "./index.js",
    output: {
        path: "./dist",
        filename: "app.js"
    },
    devtool: 'source-map',
    module: {
        // Necessary for .tag precompilation - BasePresenter will compile it on runtime, for custom templating purposes
        //preLoaders: [
        //    { test: /\.tag$/, exclude: /node_modules/, loader: 'riotjs-loader', query: { type: 'none' } }
        //],
        loaders: [
            { test: require.resolve("jquery"), loader: "expose?$!expose?jQuery" },
            { test: require.resolve("./node_modules/riot/riot+compiler"), loader: "expose?riot" },
            { test: /\.js$|/, exclude: /node_modules/, loader: 'babel-loader' }
        ]
    }
};