FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/CampanhaBrinquedo.Api/CampanhaBrinquedo.Api.csproj", "CampanhaBrinquedo.Api/"]
COPY ["src/CampanhaBrinquedo.IoC/CampanhaBrinquedo.IoC.csproj", "CampanhaBrinquedo.IoC/"]
COPY ["src/CampanhaBrinquedo.Application/CampanhaBrinquedo.Application.csproj", "CampanhaBrinquedo.Application/"]
COPY ["src/CampanhaBrinquedo.Domain/CampanhaBrinquedo.Domain.csproj", "CampanhaBrinquedo.Domain/"]
COPY ["src/CampanhaBrinquedo.Data.MongoDb/CampanhaBrinquedo.Data.MongoDb.csproj", "CampanhaBrinquedo.Data.MongoDb/"]
COPY ["src/CampanhaBrinquedo.CrossCutting/CampanhaBrinquedo.CrossCutting.csproj", "CampanhaBrinquedo.CrossCutting/"]
RUN dotnet restore "CampanhaBrinquedo.Api/CampanhaBrinquedo.Api.csproj"
COPY . .
WORKDIR "/src/CampanhaBrinquedo.Api"
RUN dotnet build "CampanhaBrinquedo.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CampanhaBrinquedo.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CampanhaBrinquedo.Api.dll"]