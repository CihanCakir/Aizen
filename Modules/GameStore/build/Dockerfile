# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution and restore dependencies
COPY . .
RUN dotnet restore "Modules/GameStore/src/Aizen.Modules.GameStore/Aizen.Modules.GameStore.csproj"

# Build the project
RUN dotnet build "Modules/GameStore/src/Aizen.Modules.GameStore/Aizen.Modules.GameStore.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "Modules/GameStore/src/Aizen.Modules.GameStore/Aizen.Modules.GameStore.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Aizen.Modules.GameStore.dll"]
