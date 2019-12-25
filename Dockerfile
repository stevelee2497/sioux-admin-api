FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
ENTRYPOINT ["dotnet", "API.dll"]
