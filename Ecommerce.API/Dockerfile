# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all project files
COPY ["Ecommerce.API/Ecommerce.API.csproj", "Ecommerce.API/"]
COPY ["Ecommerce.Servicio/Ecommerce.Servicio.csproj", "Ecommerce.Servicio/"]
COPY ["Ecommerce.DTO/Ecommerce.DTO.csproj", "Ecommerce.DTO/"]
COPY ["Ecommerce.Model/Ecommerce.Modelo.csproj", "Ecommerce.Model/"]
COPY ["Ecommerce.Repositorio/Ecommerce.Repositorio.csproj", "Ecommerce.Repositorio/"]
COPY ["Ecommerce.Utilidades/Ecommerce.Utilidades.csproj", "Ecommerce.Utilidades/"]

# Restore dependencies
RUN dotnet restore "./Ecommerce.API/Ecommerce.API.csproj"

# Copy full source and build
COPY . .
WORKDIR "/src/Ecommerce.API"
RUN dotnet build "./Ecommerce.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "./Ecommerce.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.API.dll"]