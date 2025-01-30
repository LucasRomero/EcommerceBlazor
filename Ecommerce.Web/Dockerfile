# Etapa de construcción: SDK de .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar y restaurar dependencias
COPY ["Ecommerce.Web/Ecommerce.Web.csproj", "Ecommerce.Web/"]
RUN dotnet restore "Ecommerce.Web/Ecommerce.Web.csproj"

# Copiar el resto del código y construir la aplicación
COPY . .
WORKDIR "/src/Ecommerce.Web"
RUN dotnet publish "Ecommerce.Web.csproj" -c Release -o /app/publish

# Etapa final: Servir los archivos estáticos con NGINX
FROM nginx:alpine AS final

# Copiar los archivos publicados desde la etapa de construcción
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

# Exponer el puerto 80 para servir los archivos
EXPOSE 80

# Iniciar NGINX
CMD ["nginx", "-g", "daemon off;"]
