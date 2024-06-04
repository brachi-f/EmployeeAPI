#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_ENVIRONMENT=Development


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Employees.Api/Employees.Api.csproj", "Employees.Api/"]
COPY ["Employees.Service/Employees.Service.csproj", "Employees.Service/"]
COPY ["Employees.Data/Employees.Data.csproj", "Employees.Data/"]
COPY ["Employees.Core/Employees.Core.csproj", "Employees.Core/"]
RUN dotnet restore "./Employees.Api/./Employees.Api.csproj"
COPY . .
WORKDIR "/src/Employees.Api"
RUN dotnet build "./Employees.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Employees.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Employees.Api.dll"]