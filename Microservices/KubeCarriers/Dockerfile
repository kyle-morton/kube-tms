FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KubeCarrier.API/KubeCarrier.API.csproj", "KubeCarrier.API/"]
RUN dotnet restore "KubeCarrier.API/KubeCarrier.API.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "KubeCarrier.API/KubeCarrier.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubeCarrier.API/KubeCarrier.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubeCarrier.API.dll"]