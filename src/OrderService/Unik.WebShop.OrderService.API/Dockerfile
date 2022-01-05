#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Unik.WebShop.OrderService.API/Unik.WebShop.OrderService.API.csproj", "Unik.WebShop.OrderService.API/"]
COPY ["Unik.WebShop.OrderService.Infrastructure/Unik.WebShop.OrderService.Infrastructure.csproj", "Unik.WebShop.OrderService.Infrastructure/"]
COPY ["Unik.WebShop.OrderService.Domain/Unik.WebShop.OrderService.Domain.csproj", "Unik.WebShop.OrderService.Domain/"]
RUN dotnet restore "Unik.WebShop.OrderService.API/Unik.WebShop.OrderService.API.csproj"
COPY . .
WORKDIR "/src/Unik.WebShop.OrderService.API"
RUN dotnet build "Unik.WebShop.OrderService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unik.WebShop.OrderService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unik.WebShop.OrderService.API.dll"]
