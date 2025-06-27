# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["App/Infrastructure/Microservices.Demo.Gateway/Microservices.Demo.Gateway.csproj", "App/Infrastructure/Microservices.Demo.Gateway/"]
COPY ["Libs/Microservices.Infrastructure.Trace/Microservices.Infrastructure.Trace.csproj", "Libs/Microservices.Infrastructure.Trace/"]
COPY ["Libs/Microservices.Infrastructure.Logger/Microservices.Infrastructure.Logger.csproj", "Libs/Microservices.Infrastructure.Logger/"]
RUN dotnet restore "./App/Infrastructure/Microservices.Demo.Gateway/Microservices.Demo.Gateway.csproj"
COPY . .
WORKDIR "/src/App/Infrastructure/Microservices.Demo.Gateway"
RUN dotnet build "./Microservices.Demo.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Microservices.Demo.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#USER root
#RUN mkdir -p /app/ocelot-config && chmod -R 777 /app/ocelot-config
#USER $APP_UID

ENTRYPOINT ["dotnet", "Microservices.Demo.Gateway.dll"]