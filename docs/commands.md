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

## cURL

curl -X 'GET' \

### Rest

  'https://localhost:7179/rest/Permission' \
  -H 'accept: text/plain'

### GraphQL

  curl --request POST \
  --url <https://localhost:7179/graphql/> \
  --header 'Content-Type: application/json' \
  --header 'User-Agent: insomnia/8.4.5' \
  --data '{"query":"query {\n\treadPermissionTypes {\n\t\tid\n\t\tdescription\n\t}\n}\n"}'

  wget --quiet \
  --method POST \
  --header 'User-Agent: insomnia/8.4.5' \
  --header 'Content-Type: application/json' \
  --body-data '{"query":"query {\n\treadPermissionTypes {\n\t\tid\n\t\tdescription\n\t}\n}\n"}' \
  --output-document \

- <https://localhost:7179/graphql/>

## Entity Framwork tool

dotnet tool install --global dotnet-ef

dotnet tool update --global dotnet-ef
