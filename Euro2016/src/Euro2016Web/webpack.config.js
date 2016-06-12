var webpack = require('webpack');
module.exports = {
    
    entry: {
        app: './js/index.js',
        vendor: ['angular', 'oclazyload']
    },
    output: {
        path: './wwwroot/js',
        filename: 'bundle.js',
        publicPath: '/js/'
    },
    module: {
        loaders: [
            {
                test: /\.css$/,
                exclude: /node_modules/,
                loader: "style-loader!css-loader"
            },
            {
                test: /\.(jpg|png)$/,
                exclude: /node_modules/,
                loader: "url-loader?limit=10000&name=../images/[hash].[ext]"
            },
            {
                test: /\.less$/,
                exclude: /node_modules/,
                loader: "style-loader!css-loader!less-loader"
            },
        {
            test: /\.html$/,
            exclude: /node_modules/,
            loader: "raw-loader"
        }

        ]
    },
    

    plugins: [
        new webpack.optimize.DedupePlugin(),
        new webpack.optimize.CommonsChunkPlugin({
            name: 'vendor',
            filename: 'vendor.bundle.js'
        }),
        new webpack.DefinePlugin({
            ON_DEMO: process.env.NODE_ENV === 'demo'
        })
    ]
}