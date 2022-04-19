rmdir /s /q pack
mkdir pack

cd ../LightningAlert
dotnet publish -c Release -r win-x64 --output ../Release/pack -p:PublishSingleFile=true  -p:IncludeAllContentForSelfExtract=true -p:PublishTrimmed=true
