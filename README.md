## samples:aspnetapp[https://github.com/dotnet/dotnet-docker/tree/main/samples/aspnetapp]

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

## Install Docker-EE

### PowerShell

`Install-WindowsFeature -Name Containers`

`[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12`

`Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force`

`Install-Module -Name DockerMsftProvider -Repository PSGallery -Force`

`Install-Package -Name docker -ProviderName DockerMsftProvider -Force`

`Start-Service docker`

`docker --version`


### Zip [https://dockermsft.blob.core.windows.net/dockercontainer/DockerMsftIndex.json]

`Expand-Archive docker-17.06.2-ee-16.zip -DestinationPath $Env:ProgramFiles Force`

`[Environment]::SetEnvironmentVariable("PATH", [Environment]::GetEnvironmentVariable("PATH") + ";" + $Env:ProgramFiles + "/docker" )`

`dockerd --register-service`

`Start-Service docker`

`docker --version`

## command

### docker build image

`docker build -f <Dockerfile Name> -t <Image Name> .`

### create 

`dotnet dev-certs https -ep <path> -p <password>

`dotnet dev-certs https --trust`

### save

`docker save -o <name>.tar <image>`


### load

`docker load -i <name>.tar`


### docker run container

```
docker run -d ^
-v "<host>:<container>" ^
-p <host>:<container> ^
-e "<key>=<value>" ^
-P --name <container name> ^
--user ContainerAdministrator ^
<image name>
```

## Backend

### docker build image

`docker build -f Backend.Copy.Dockerfile -t demonetcoredocker.backend .`

`docker build -f Backend.Build.Publish.Dockerfile -t demonetcoredocker.backend .`

### create 

`dotnet dev-certs https -ep d:\GitHub\pisces\DemoNetCoreDocker\DemoPublishDocker\https\demonetcoredocker.pfx -p 1234`

### save

`docker save -o demonetcoredocker.backend.tar demonetcoredocker.backend`

### load

`docker load -i demonetcoredocker.backend.tar`

### docker run container

```
docker run -d ^
-v "d:\GitHub\pisces\DemoNetCoreDocker\logs\:c:\logs" ^
-v "d:\GitHub\pisces\DemoNetCoreDocker\https\:c:\https" ^
-p 5001:443 ^
-e "ASPNETCORE_ENVIRONMENT=Production" ^
-e "ASPNETCORE_URLS=https://+;http://+" ^
-e ASPNETCORE_HTTPS_PORT=5001 ^
-e ASPNETCORE_Kestrel__Certificates__Default__Password="1234" ^
-e ASPNETCORE_Kestrel__Certificates__Default__Path="c:\https\demonetcoredocker.pfx" ^
-P --name DemoNetCoreDocker.backend ^
--user ContainerAdministrator ^
demonetcoredocker.backend
```

```
docker run -d ^
-v "d:\GitHub\pisces\DemoNetCoreDocker\logs\:c:\logs" ^
-v "d:\GitHub\pisces\DemoNetCoreDocker\https\:c:\https" ^
-p 5001:443 ^
-P --name DemoNetCoreDocker.backend ^
--user ContainerAdministrator ^
demonetcoredocker.backend
```

## Batch

### docker build image

`docker build -f Batch.Copy.Dockerfile -t demonetcoredocker.batch .`

`docker build -f Batch.Build.Publish.Dockerfile -t demonetcoredocker.batch .`

### docker run container

```
docker run -d --rm ^
-e "ASPNETCORE_PROGID=TEST" ^
--user ContainerAdministrator ^
demonetcoredocker.batch
```

```
docker run -d --rm ^
-v "d:\GitHub\pisces\DemoNetCoreDocker\logs\:c:\logs" ^
-e "ASPNETCORE_PROGID=TEST" ^
--user ContainerAdministrator ^
demonetcoredocker.batch
```

## Docker 教學 - 打包 ASP.NET Core 前後端專案 Docker Image[https://blog.johnwu.cc/article/docker-build-asp-net-core-image.html]

## NuGet restore failing in Docker Container[https://codebuckets.com/2020/08/01/nuget-restore-failing-in-docker-container/]

`curl -v https://api.nuget.org/v3/index.json`
