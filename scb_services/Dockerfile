FROM mcr.microsoft.com/dotnet/aspnet:8.0 
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

COPY /bin/Debug/net8.0/. ./

WORKDIR /app
EXPOSE 5001
ENV ASPNETCORE_URLS=http://+:5001
ENTRYPOINT ["dotnet", "scb_services.dll"]