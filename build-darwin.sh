#!/bin/bash
git clone https://github.com/octoblu/gateblu-ui.git
cd ./gateblu-ui
npm install
mkdir dist
curl http://nodejs.org/dist/v0.10.32/node-v0.10.32-darwin-x64.tar.gz -o dist/node-v0.10.32-darwin-x64.tar.gz
tar -zxf dist/node-v0.10.32-darwin-x64.tar.gz
rm dist/node-v0.10.32-darwin-x64.tar.gz

curl http://dl.node-webkit.org/v0.10.5/node-webkit-v0.10.5-osx-x64.zip -o node-webkit-v0.10.5-osx-x64.zip
unzip -d node-webkit-v0.10.5-osx-x64.zip
rm node-webkit-v0.10.5-osx-x64.zip
mv node-webkit gateblu