#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Carpool.Api/Carpool.Api.csproj", "Carpool.Api/"]
COPY ["Carpool.BLL/Carpool.BLL.csproj", "Carpool.BLL/"]
COPY ["Carpool.DAL/Carpool.DAL.csproj", "Carpool.DAL/"]
RUN dotnet restore "Carpool.Api/Carpool.Api.csproj"
COPY . .
WORKDIR "/src/Carpool.Api"
RUN dotnet build "Carpool.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carpool.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carpool.Api.dll"]