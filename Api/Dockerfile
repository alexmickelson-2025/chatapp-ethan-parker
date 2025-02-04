FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY Api/Api.csproj Api/Api.csproj
RUN dotnet restore Api/Api.csproj

COPY Logic/Logic.csproj Logic/Logic.csproj
RUN dotnet restore Logic/Logic.csproj

COPY . .

RUN dotnet publish -c Release Api/Api.csproj -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
CMD ["dotnet", "Api.dll"]