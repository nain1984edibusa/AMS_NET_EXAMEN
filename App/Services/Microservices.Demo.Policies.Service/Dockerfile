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
COPY ["App/Services/Microservices.Demo.Policies.Service/Microservices.Demo.Policies.Service.csproj", "App/Services/Microservices.Demo.Policies.Service/"]
COPY ["Libs/Microservices.Infrastructure.Kafka/Microservices.Infrastructure.Kafka.csproj", "Libs/Microservices.Infrastructure.Kafka/"]
COPY ["Libs/Microservices.Infrastructure.Persistences/Microservices.Infrastructure.Persistences.csproj", "Libs/Microservices.Infrastructure.Persistences/"]
COPY ["Libs/Microservices.SharedKernel/Microservices.SharedKernel.csproj", "Libs/Microservices.SharedKernel/"]
COPY ["Libs/Microservices.Messages/Microservices.Messages.csproj", "Libs/Microservices.Messages/"]
COPY ["App/Messaging/Microservices.Demo.Messages/Microservices.Demo.Messages.csproj", "App/Messaging/Microservices.Demo.Messages/"]
COPY ["App/RestClients/Microservices.Demo.RestClients/Microservices.Demo.RestClients.csproj", "App/RestClients/Microservices.Demo.RestClients/"]
COPY ["Libs/Microservices.Infrastructure.Http/Microservices.Infrastructure.Http.csproj", "Libs/Microservices.Infrastructure.Http/"]
COPY ["Libs/Microservices.Infrastructure.Trace/Microservices.Infrastructure.Trace.csproj", "Libs/Microservices.Infrastructure.Trace/"]
COPY ["Libs/Microservices.Infrastructure.Logger/Microservices.Infrastructure.Logger.csproj", "Libs/Microservices.Infrastructure.Logger/"]
RUN dotnet restore "./App/Services/Microservices.Demo.Policies.Service/Microservices.Demo.Policies.Service.csproj"
COPY . .
WORKDIR "/src/App/Services/Microservices.Demo.Policies.Service"
RUN dotnet build "./Microservices.Demo.Policies.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Microservices.Demo.Policies.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Demo.Policies.Service.dll"]