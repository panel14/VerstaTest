const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const ReactRefreshWebpackPlugin = require('@pmmmwh/react-refresh-webpack-plugin');

let mode = 'development';
if (process.env.NODE_ENV === 'production') {
    mode = process.env.NODE_ENV
}

const plugins = [
    new HtmlWebpackPlugin({
        template: './src/index.html',
        filename: './index.html'
    }),
    new MiniCssExtractPlugin({
        filename: '[name].[contenthash].css'
    })
];

if (process.env.SERVE) {
    plugins.push(new ReactRefreshWebpackPlugin());
}

module.exports = {
    mode,
    plugins,
    entry: './src/index.js',
    devtool: 'source-map',
    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'bundles'),
        assetModuleFilename: 'assets/[hash][ext][query]',
        clean: true,
    },

    resolve: {
        extensions: ['.js', '.jsx']
    },

    devServer: {
        hot: true
    },

    module: {
        rules: [
            {
                test: /\.(html)$/, 
                use: ['html-loader']
            },
            {
                test: /\.(s[ac]|c)ss$/i,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                    'postcss-loader',
                    'sass-loader',
                ]
            },
            {
                test: /\.(png|jpe?g|gif|svg|webp|ico)$/i,
                type: mode === 'production' ? 'asset' : 'asset/resource'
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        cacheDirectory: true,
                    }
                }
            },
            {
                test: /\.jsx$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        cacheDirectory: true
                    }
                }
            }
        ]
    }
}