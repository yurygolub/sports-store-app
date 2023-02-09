#  "Sports Store" Application

## SportsStore

### Build and Run
```sh
git clone https://github.com/yurygolub/sports-store-app.git
```

```sh
cd sports-store-app\SportsStore
```

```sh
dotnet run
```

### Release
```sh
dotnet publish SportsStore/SportsStore.csproj --configuration Release --output publish --property:DebugType=None --property:DebugSymbols=false --property:PublishSingleFile=true --no-self-contained
```