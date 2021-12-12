FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KubeTMS.Server/KubeTMS.Server.csproj", "KubeTMS.Server/"]
COPY ["KubeTMS.Client/KubeTMS.Client.csproj", "KubeTMS.Client/"]
COPY ["KubeTMS.Shared/KubeTMS.Shared.csproj", "KubeTMS.Shared/"]
RUN dotnet restore "KubeTMS.Server/KubeTMS.Server.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "KubeTMS.Server/KubeTMS.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubeTMS.Server/KubeTMS.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubeTMS.Server.dll"]