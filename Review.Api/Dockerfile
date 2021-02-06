#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Review.Api/Review.Api.csproj", "Review.Api/"]
COPY ["Review.Data/Review.Data.csproj", "Review.Data/"]
COPY ["Review.Service/Review.Service.csproj", "Review.Service/"]
RUN dotnet restore "Review.Api/Review.Api.csproj"
COPY . .
WORKDIR "/src/Review.Api"
RUN dotnet build "Review.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Review.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Review.Api.dll"]