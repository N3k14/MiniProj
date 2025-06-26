FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/WebApi/WebApi.csproj", "Backend/WebApi/"]
COPY ["Backend/Application/Application.csproj", "Backend/Application/"]
COPY ["Backend/Domain/Domain.csproj", "Backend/Domain/"]
COPY ["Backend/SharedKernel/SharedKernel.csproj", "Backend/SharedKernel/"]
COPY ["Backend/Infrastructure/Infrastructure.csproj", "Backend/Infrastructure/"]
RUN dotnet restore "Backend/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/Backend/WebApi"
RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
