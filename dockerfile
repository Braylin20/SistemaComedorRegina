# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copia primero los archivos de proyecto
COPY ["SistemaComedorRegina/SistemaComedorRegina.csproj", "SistemaComedorRegina/"]
COPY ["SistemaComedorRegina.Client/SistemaComedorRegina.Domain.csproj", "SistemaComedorRegina.Client/"]

# 2. Restaura dependencias
RUN dotnet restore "SistemaComedorRegina/SistemaComedorRegina.csproj"

# 3. Copia TODO el código fuente
COPY . .

# 4. Publica
WORKDIR "/src/SistemaComedorRegina"
RUN dotnet publish "SistemaComedorRegina.csproj" -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SistemaComedorRegina.dll"]