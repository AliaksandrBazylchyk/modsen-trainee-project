#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ModsenProject.ProducerApi/ModsenProject.ProducerApi.csproj", "ModsenProject.ProducerApi/"]
RUN dotnet restore "ModsenProject.ProducerApi/ModsenProject.ProducerApi.csproj"
COPY . .
WORKDIR "/src/ModsenProject.ProducerApi"
RUN dotnet build "ModsenProject.ProducerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModsenProject.ProducerApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModsenProject.ProducerApi.dll"]