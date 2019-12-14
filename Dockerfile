FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 2704
ENTRYPOINT ["dotnet", "API.dll"]
