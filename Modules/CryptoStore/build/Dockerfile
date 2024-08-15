# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution and restore dependencies
COPY . .
RUN dotnet restore "Modules/CryptoStore/src/Aizen.Modules.CryptoStore/Aizen.Modules.CryptoStore.csproj"

# Build the project
RUN dotnet build "Modules/CryptoStore/src/Aizen.Modules.CryptoStore/Aizen.Modules.CryptoStore.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "Modules/CryptoStore/src/Aizen.Modules.CryptoStore/Aizen.Modules.CryptoStore.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Aizen.Modules.CryptoStore.dll"]
