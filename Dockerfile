FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "API.dll"]
