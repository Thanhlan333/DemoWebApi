# Sử dụng image cơ sở .NET SDK để build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy file .csproj và restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy toàn bộ mã nguồn và build
COPY . ./
RUN dotnet publish -c Release -o out

# Sử dụng image runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Đặt biến môi trường để lắng nghe trên cổng do Render cung cấp
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# Lệnh khởi động ứng dụng
ENTRYPOINT ["dotnet", "APINEON.dll"]