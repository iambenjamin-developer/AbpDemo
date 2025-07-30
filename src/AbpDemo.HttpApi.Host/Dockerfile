# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/AbpDemo.HttpApi.Host/AbpDemo.HttpApi.Host.csproj", "src/AbpDemo.HttpApi.Host/"]
COPY ["src/AbpDemo.Application/AbpDemo.Application.csproj", "src/AbpDemo.Application/"]
COPY ["src/AbpDemo.Domain/AbpDemo.Domain.csproj", "src/AbpDemo.Domain/"]
COPY ["src/AbpDemo.Domain.Shared/AbpDemo.Domain.Shared.csproj", "src/AbpDemo.Domain.Shared/"]
COPY ["src/AbpDemo.Application.Contracts/AbpDemo.Application.Contracts.csproj", "src/AbpDemo.Application.Contracts/"]
COPY ["src/AbpDemo.EntityFrameworkCore/AbpDemo.EntityFrameworkCore.csproj", "src/AbpDemo.EntityFrameworkCore/"]
COPY ["src/AbpDemo.HttpApi/AbpDemo.HttpApi.csproj", "src/AbpDemo.HttpApi/"]
RUN dotnet restore "./src/AbpDemo.HttpApi.Host/AbpDemo.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/AbpDemo.HttpApi.Host"
RUN dotnet build "./AbpDemo.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AbpDemo.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AbpDemo.HttpApi.Host.dll"]