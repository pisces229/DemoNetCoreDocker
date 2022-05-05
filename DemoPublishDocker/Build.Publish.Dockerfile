#Stage 1: Define base image that will be used for production

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR "/app"
#EXPOSE 80
EXPOSE 443

#Stage 2: Build and publish the code

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR "/src"
COPY ["DemoNetCoreDocker.Backend/DemoNetCoreDocker.Backend.csproj", "DemoNetCoreDocker.Backend/"]
RUN dotnet restore "DemoNetCoreDocker.Backend/DemoNetCoreDocker.Backend.csproj"
COPY . .
WORKDIR "/src/DemoNetCoreDocker.Backend"
RUN dotnet build "DemoNetCoreDocker.Backend.csproj" -c Release -o "/app/build"

FROM build AS publish
RUN dotnet publish "DemoNetCoreDocker.Backend.csproj" -c Release -o "/app/publish"

#Stage 3: Build and publish the code

FROM base AS final
WORKDIR "/app"
COPY --from=publish "/app/publish" .
VOLUME ["c:/logs","c:/https"]
ENV ASPNETCORE_ENVIRONMENT="Production"
#ENV ASPNETCORE_URLS="https://+;http://+"
ENV ASPNETCORE_URLS="https://+"
ENV ASPNETCORE_HTTPS_PORT="5001"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="1234"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="c:/https/demonetcoredocker.pfx"
ENTRYPOINT ["dotnet", "DemoNetCoreDocker.Backend.dll"]
#CMD "ping -t localhost"