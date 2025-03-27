#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

ENV ASPNETCORE_HTTP_PORTS=80

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ETraveller.api.Travels/ETraveller.api.Travels.csproj", "ETraveller.api.Travels/"]
COPY ["ETraveller.Common/ETraveller.Common.csproj", "ETraveller.Common/"]
RUN dotnet restore "./ETraveller.api.Travels/ETraveller.api.Travels.csproj"
COPY . .
WORKDIR "/src/ETraveller.api.Travels"
RUN dotnet build "./ETraveller.api.Travels.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ETraveller.api.Travels.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ETraveller.api.Travels.dll"]