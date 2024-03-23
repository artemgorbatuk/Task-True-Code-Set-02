# Образ asp.net
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS aspnet
EXPOSE 8080

# Образ sdk
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS sdk
ARG BUILD_CONFIGURATION=Release

# Копируйте исходников проектов в папку /src
WORKDIR /src
#COPY . .
COPY Core/ Core/
COPY Datasource/ Datasource/
COPY Repositories/ Repositories/
COPY Services/ Services/
COPY Endpoints/ Endpoints/

# Восстанавливайте зависимости для всех проектов
#RUN dotnet restore
RUN dotnet restore ./Core/Core.csproj
RUN dotnet restore ./Datasource/Datasource.csproj
RUN dotnet restore ./Repositories/Repositories.csproj
RUN dotnet restore ./Services/Services.csproj
RUN dotnet restore ./Endpoints/Endpoints.csproj

# Сборка проекта Endpoints в папку /app/build
RUN dotnet build "Endpoints/Endpoints.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

# Публикаци проекта Endpoints в папку /app/publish
FROM sdk AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Endpoints/Endpoints.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

# Запуск веб сервиса из папки /app/publish
FROM aspnet AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Endpoints.dll"]

# Очистка места от установочных файлов
RUN apt-get clean && \
    rm -rf /var/lib/apt/lists