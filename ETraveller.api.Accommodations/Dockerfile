#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_HTTP_PORTS=80
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ETraveller.api.Accommodations/ETraveller.api.Accommodations.csproj", "ETraveller.api.Accommodations/"]
COPY ["ETraveller.Common/ETraveller.Common.csproj", "ETraveller.Common/"]
RUN dotnet restore "./ETraveller.api.Accommodations/ETraveller.api.Accommodations.csproj"
COPY . .
WORKDIR "/src/ETraveller.api.Accommodations"
RUN dotnet build "./ETraveller.api.Accommodations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ETraveller.api.Accommodations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ETraveller.api.Accommodations.dll"]