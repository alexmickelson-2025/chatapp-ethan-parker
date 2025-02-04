FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY Client/Client.csproj Client/Client.csproj
RUN dotnet restore Client/Client.csproj

COPY Logic/Logic.csproj Logic/Logic.csproj
RUN dotnet restore Logic/Logic.csproj

COPY . .
RUN dotnet publish -c Release Client/Client.csproj -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
CMD ["dotnet", "Client.dll"]