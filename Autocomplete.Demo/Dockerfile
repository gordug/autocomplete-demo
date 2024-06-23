FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Autocomplete.Demo/Autocomplete.Demo.csproj", "Autocomplete.Demo/"]
RUN dotnet restore "Autocomplete.Demo/Autocomplete.Demo.csproj"
COPY . .
WORKDIR "/src/Autocomplete.Demo"
RUN dotnet build "Autocomplete.Demo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Autocomplete.Demo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Autocomplete.Demo.dll"]
