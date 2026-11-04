# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Project file copy karke restore karein
COPY ["*.csproj", "./"]
RUN dotnet restore

# Baaki source code copy karke release build banayein
COPY . .
RUN dotnet publish -c Release -o /app/publish

# 2. Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render ke default port ko expose karein
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

# Note: "Takyon.dll" ko apne project ke actual dll name se replace karein
ENTRYPOINT ["dotnet", "Takyon.dll"]
