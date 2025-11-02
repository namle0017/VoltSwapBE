# Sử dụng image .NET chính thức
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file và restore dependencies
COPY ["VoltSwap.API/VoltSwap.API.csproj", "VoltSwap.API/"]
RUN dotnet restore "VoltSwap.API/VoltSwap.API.csproj"

# Copy toàn bộ source code và build
COPY . .
WORKDIR "/src/VoltSwap.API"
RUN dotnet publish "VoltSwap.API.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VoltSwap.API.dll"]
