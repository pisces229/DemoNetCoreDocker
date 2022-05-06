FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY ./publish/ .
VOLUME ["c:/logs"]
ENV ASPNETCORE_ENVIRONMENT="Production"
ENTRYPOINT ["dotnet", "DemoNetCoreDocker.Batch.dll"]
#CMD "ping -t localhost"