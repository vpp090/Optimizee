#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ArtificialIntel.API/ArtificialIntel.API.csproj", "ArtificialIntel.API/"]
COPY ["CommonPackages/OptimalPackage/OptimalPackage.csproj", "CommonPackages/OptimalPackage/"]

RUN dotnet restore "./ArtificialIntel.API/./ArtificialIntel.API.csproj"
COPY . .
WORKDIR "/src/ArtificialIntel.API"
RUN dotnet build "./ArtificialIntel.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ArtificialIntel.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY ["ArtificialIntel.API/appsettings.json", "./"]
COPY ["ArtificialIntel.API/appsettings.Development.json", "./"]

ENTRYPOINT ["dotnet", "ArtificialIntel.API.dll"]