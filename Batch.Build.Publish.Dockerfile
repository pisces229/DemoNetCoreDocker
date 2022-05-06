#Stage 1: Define base image that will be used for production

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR "/app"

#Stage 2: Build and publish the code

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR "/src"
COPY ["DemoNetCoreDocker.Batch/DemoNetCoreDocker.Batch.csproj", "DemoNetCoreDocker.Batch/"]
RUN dotnet restore "DemoNetCoreDocker.Batch/DemoNetCoreDocker.Batch.csproj"
COPY . .
WORKDIR "/src/DemoNetCoreDocker.Batch"
RUN dotnet build "DemoNetCoreDocker.Batch.csproj" -c Release -o "/app/build"

FROM build AS publish
RUN dotnet publish "DemoNetCoreDocker.Batch.csproj" -c Release -o "/app/publish"

#Stage 3: Build and publish the code

FROM base AS final
WORKDIR "/app"
COPY --from=publish "/app/publish" .
VOLUME ["c:/logs"]
ENV ASPNETCORE_ENVIRONMENT="Production"
ENTRYPOINT ["dotnet", "DemoNetCoreDocker.Batch.dll"]
#CMD "ping -t localhost"