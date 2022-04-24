#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://*:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Registry.Api/Registry.Api.csproj", "Registry.Api/"]
COPY ["Registry.Api.Integration/Registry.Api.Integration.csproj", "Registry.Api.Integration/"]
RUN dotnet restore "Registry.Api/Registry.Api.csproj"
COPY . .
WORKDIR "/src/Registry.Api"
RUN dotnet build "Registry.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Registry.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Registry.Api.dll"]