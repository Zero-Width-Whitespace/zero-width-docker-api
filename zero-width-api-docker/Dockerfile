#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-nanoserver-1903 AS build
WORKDIR /src
COPY . .

RUN dir

RUN dotnet restore --configfile "Nuget.config" "zero-width-api-docker.csproj"
RUN dotnet build "zero-width-api-docker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "zero-width-api-docker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "zero-width-api-docker.dll"]