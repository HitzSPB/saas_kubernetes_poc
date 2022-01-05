#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Unik.WebShop.CustomerService.Api/Unik.WebShop.CustomerService.Api.csproj", "Unik.WebShop.CustomerService.Api/"]
COPY ["Unik.WebShop.CustomerService.Infrastructure/Unik.WebShop.CustomerService.Infrastructure.csproj", "Unik.WebShop.CustomerService.Infrastructure/"]
COPY ["Unik.WebShop.CustomerService.Domain/Unik.WebShop.CustomerService.Domain.csproj", "Unik.WebShop.CustomerService.Domain/"]
RUN dotnet restore "Unik.WebShop.CustomerService.Api/Unik.WebShop.CustomerService.Api.csproj"
COPY . .
WORKDIR "/src/Unik.WebShop.CustomerService.Api"
RUN dotnet build "Unik.WebShop.CustomerService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unik.WebShop.CustomerService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unik.WebShop.CustomerService.Api.dll"]