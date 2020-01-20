FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["zero-width-api-docker.csproj", "zero-width-api-docker/"]
COPY ["Nuget.config", "zero-width-api-docker/"]
RUN dotnet restore "zero-width-api-docker/zero-width-api-docker.csproj"
COPY . .
WORKDIR "/src/zero-width-api-docker"
RUN dotnet build "zero-width-api-docker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "zero-width-api-docker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "zero-width-api-docker.dll"]