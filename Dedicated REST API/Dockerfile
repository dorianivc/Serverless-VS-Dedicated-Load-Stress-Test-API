#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Dedicated REST API/Dedicated REST API.csproj", "Dedicated REST API/"]
RUN dotnet restore "Dedicated REST API/Dedicated REST API.csproj"
COPY . .
WORKDIR "/src/Dedicated REST API"
RUN dotnet build "Dedicated REST API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dedicated REST API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dedicated REST API.dll"]