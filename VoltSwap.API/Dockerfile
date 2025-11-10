# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# COPY TẤT CẢ .CSPROJ (theo đúng đường dẫn tuyệt đối)
COPY VoltSwap.API/*.csproj ./VoltSwap.API/
COPY VoltSwap.BusinessLayer/*.csproj ./VoltSwap.BusinessLayer/
COPY VoltSwap.Common/*.csproj ./VoltSwap.Common/
COPY VoltSwap.DAL/*.csproj ./VoltSwap.DAL/

# Restore
RUN dotnet restore "VoltSwap.API/VoltSwap.API.csproj"

# BƯỚC QUAN TRỌNG: COPY TOÀN BỘ SOURCE CODE
COPY . .

# Publish
WORKDIR /src/VoltSwap.API
RUN dotnet publish "VoltSwap.API.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VoltSwap.API.dll"]
