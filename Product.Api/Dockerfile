#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY Product.Api/Product.Api.csproj Product.Api/
COPY Product.Data/Product.Data.csproj Product.Data/
COPY Product.Service/Product.Service.csproj Product.Service/
COPY Common/Common.csproj Common/
RUN dotnet restore Product.Api/Product.Api.csproj
COPY . .
WORKDIR /src/Product.Api
RUN dotnet build Product.Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Product.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app

ENV ConnectionStrings__Products="Data Source=db,1433;Initial Catalog=Products;uid=sa;pwd=TesT111t!;Integrated Security=false;MultipleActiveResultSets=True"

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Product.Api.dll"]