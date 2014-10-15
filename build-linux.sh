#!/bin/bash
https://github.com/octoblu/gateblu-build-dist/archive/master.zip
cd ./gateblu-ui
npm install
mkdir dist
mkdir tmp

curl -o tmp/node-v0.10.32-linux-x64.tar.gz http://nodejs.org/dist/v0.10.32/node-v0.10.32-linux-x64.tar.gz
tar -zxf tmp/node-v0.10.32-linux-x64.tar.gz --directory dist/


curl -o tmp/node-webkit-v0.10.5-linux-x64.tar.gz http://dl.node-webkit.org/v0.10.5/node-webkit-v0.10.5-linux-x64.tar.gz
tar -zxf tmp/node-webkit-v0.10.5-linux-x64 --directory dist/
mv tmp/node-webkit-v0.10.5-linux-x64/* .

rm -rf ./tmp
