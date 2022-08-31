#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ModsenProject.ConsumerApi/ModsenProject.ConsumerApi.csproj", "ModsenProject.ConsumerApi/"]
RUN dotnet restore "ModsenProject.ConsumerApi/ModsenProject.ConsumerApi.csproj"
COPY . .
WORKDIR "/src/ModsenProject.ConsumerApi"
RUN dotnet build "ModsenProject.ConsumerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModsenProject.ConsumerApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModsenProject.ConsumerApi.dll"]