### Docker 教學 - 打包 ASP.NET Core 前後端專案 Docker Image[https://blog.johnwu.cc/article/docker-build-asp-net-core-image.html]

### 使用 Docker over HTTPS 裝載 ASP.NET Core 映射[https://docs.microsoft.com/zh-tw/aspnet/core/security/docker-https?view=aspnetcore-6.0]

### 容器化 .NET 應用程式[https://docs.microsoft.com/zh-tw/dotnet/core/docker/build-container?tabs=windows]

### Step by step: Building custom ASP.NET Core containers with Docker[https://www.pluralsight.com/blog/software-development/how-to-build-custom-containers-docker]

### ASP.NET Core URLs 設定的套用順序[https://blog.yowko.com/aspdotnet-core-urls-setting-sequence/]

### samples:aspnetapp[https://github.com/dotnet/dotnet-docker/tree/main/samples/aspnetapp]

`docker pull mcr.microsoft.com/dotnet/core/samples:aspnetapp`

`docker run -d -p 8000:80 mcr.microsoft.com/dotnet/core/samples:aspnetapp`

`dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p { password here }`

`dotnet dev-certs https --trust`

```
docker run -d ^
-v %USERPROFILE%\.aspnet\https:c:\https\ ^
-p 8000:80 ^
-p 8001:443 ^
-e ASPNETCORE_URLS="https://+;http://+" ^
-e ASPNETCORE_HTTPS_PORT=8001 ^
-e ASPNETCORE_Kestrel__Certificates__Default__Password="password" ^
-e ASPNETCORE_Kestrel__Certificates__Default__Path=\https\aspnetapp.pfx ^
--user ContainerAdministrator ^
mcr.microsoft.com/dotnet/core/samples:aspnetapp
```

> create + start = run

`docker create -p <host:container> --name <name> <image>`

`docker start <name>`

`docker run -d -p <host:container> --name <name> <image>`

> mount

`docker run ... --mount source=myvol2,target=/app`

`docker run ... --mount type=volume,source="$(pwd)"/target,target=/app `

> volume

`docker run ... --volume "<host>:<container>"`

> save

`docker save -o <name>.tar <image>`

> load

`docker load -i <name>.tar`


