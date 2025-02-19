FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY ImageApi/ImageApi.csproj ImageApi/ImageApi.csproj
RUN dotnet restore ImageApi/ImageApi.csproj

COPY . .
RUN dotnet publish -c Release ImageApi/ImageApi.csproj -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
CMD ["dotnet", "ImageApi.dll"]