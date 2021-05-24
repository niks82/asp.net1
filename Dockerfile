FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Products_Microservice/Products_Microservice.csproj", "Products_Microservice/"]
RUN dotnet restore "Products_Microservice/Products_Microservice.csproj"
COPY . .
WORKDIR "/src/Products_Microservice"
RUN dotnet build "Products_Microservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Products_Microservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Products_Microservice.dll"]