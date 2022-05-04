#Stage 1: Define base image that will be used for production

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR "/app"
EXPOSE 80
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
ENTRYPOINT ["dotnet", "DemoNetCoreDocker.Backend.dll"]
