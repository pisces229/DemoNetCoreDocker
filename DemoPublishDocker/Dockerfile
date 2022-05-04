FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY ./publish/ .
ENTRYPOINT ["dotnet", "DemoNetCoreDocker.Backend.dll"]
#CMD "ping -t localhost"