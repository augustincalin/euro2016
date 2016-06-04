module.exports = {
    entry: ['./js/index.js'],
    output: {
        path: 'wwwroot/js/',
        filename: 'bundle.js'
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
                exclude:/node_modules/,
                loader: "url-loader?limit=10000&name=../images/[hash].[ext]"
            },
            {
				test: /\.less$/,
				exclude: /node_modules/,
				loader: "style-loader!css-loader!less-loader"
			}

        ]
    },
}