FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
#EXPOSE 80
EXPOSE 443
COPY ./publish/ .
VOLUME ["c:/logs","c:/https"]
ENV ASPNETCORE_ENVIRONMENT="Production"
#ENV ASPNETCORE_URLS="https://+;http://+"
ENV ASPNETCORE_URLS="https://+"
ENV ASPNETCORE_HTTPS_PORT="5001"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="1234"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="c:/https/demonetcoredocker.pfx"
ENTRYPOINT ["dotnet", "DemoNetCoreDocker.Backend.dll"]
#CMD "ping -t localhost"