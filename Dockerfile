FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR ssl
COPY ssl /app/ssl
COPY . .
WORKDIR ../
COPY . .

RUN dotnet restore --disable-parallel
RUN dotnet build "src/API/API.csproj" -c Release --no-restore

RUN dotnet publish "src/API/API.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "API.dll"]
