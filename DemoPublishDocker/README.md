
### docker build image

`docker build -f <Dockerfile Name> -t <Image Name> .`

`docker build -f Dockerfile -t demonetcoredocker .`

### create 

`dotnet dev-certs https -ep <path> -p <password>

`dotnet dev-certs https --trust`

`dotnet dev-certs https -ep d:\GitHub\pisces\DemoNetCoreDocker\DemoPublishDocker\https\demonetcoredocker.pfx -p 1234`

### save

`docker save -o <name>.tar <image>`

`docker save -o demonetcoredocker.tar demonetcoredocker`

### load

`docker load -i <name>.tar`

`docker load -i demonetcoredocker.tar`

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

```
docker run -d ^
-v "d:\GitHub\pisces\DemoNetCoreDocker\DemoPublishDocker\logs\:c:\logs" ^
-v "d:\GitHub\pisces\DemoNetCoreDocker\DemoPublishDocker\https\:c:\https" ^
-p 5001:443 ^
-e "ASPNETCORE_ENVIRONMENT=Production" ^
-e "ASPNETCORE_URLS=https://+:443" ^
-e ASPNETCORE_HTTPS_PORT=5001 ^
-e ASPNETCORE_Kestrel__Certificates__Default__Password="1234" ^
-e ASPNETCORE_Kestrel__Certificates__Default__Path="c:\https\demonetcoredocker.pfx" ^
-P --name DemoNetCoreDocker ^
--user ContainerAdministrator ^
demonetcoredocker
```

