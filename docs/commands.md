# Console commands

 xunit

dotnet new xunit -n AccessCompanionApi.Tests

cd AccessCompanionApi.Tests

dotnet add reference ../AccessCompanionApi/AccessCompanionApi.csproj

## Serilog

dotnet add package Serilog.AspNetCore

## Docker

ps2

docker-compose up -d
docker-compose stop