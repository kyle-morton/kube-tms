FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KubeCustomer.API/KubeCustomer.API.csproj", "KubeCustomer.API/"]
RUN dotnet restore "KubeCustomer.API/KubeCustomer.API.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "KubeCustomer.API/KubeCustomer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubeCustomer.API/KubeCustomer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubeCustomer.API.dll"]