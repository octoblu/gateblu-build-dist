#!/bin/bash
curl -L -O https://github.com/octoblu/gateblu-ui/archive/master.zip
unzip master.zip
mv gateblu-ui-master gateblu-ui
rm master.zip

cd ./gateblu-ui
npm install
mkdir dist
mkdir tmp

curl http://nodejs.org/dist/v0.10.32/node-v0.10.32-darwin-x64.tar.gz -o tmp/node-v0.10.32-darwin-x64.tar.gz
tar -zxf tmp/node-v0.10.32-darwin-x64.tar.gz --directory dist/

curl http://dl.node-webkit.org/v0.10.5/node-webkit-v0.10.5-osx-x64.zip -o tmp/node-webkit-v0.10.5-osx-x64.zip
unzip tmp/node-webkit-v0.10.5-osx-x64.zip -d tmp/

mv tmp/node-webkit-v0.10.5-osx-x64/* .

rm -rf ./tmp
