# Sử dụng image .NET chính thức
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# COPY TẤT CẢ .CSPROJ TRƯỚC ĐỂ RESTORE CHÍNH XÁC
COPY ["VoltSwap.API/VoltSwap.API.csproj", "VoltSwap.API/"]
COPY ["VoltSwap.BusinessLayer/VoltSwap.BusinessLayer.csproj", "VoltSwap.BusinessLayer/"]
COPY ["VoltSwap.Common/VoltSwap.Common.csproj", "VoltSwap.Common/"]
COPY ["VoltSwap.DAL/VoltSwap.DAL.csproj", "VoltSwap.DAL/"]

# Restore với project chính
RUN dotnet restore "VoltSwap.API/VoltSwap.API.csproj"

# Copy toàn bộ source code
COPY . .

# Build & publish
WORKDIR "/src/VoltSwap.API"
RUN dotnet publish "VoltSwap.API.csproj" -c Release -o /app/publish --no-restore

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VoltSwap.API.dll"]
