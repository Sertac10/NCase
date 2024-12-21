#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/NCase.API/NCase.API.csproj", "Presentation/NCase.API/"]
COPY ["Core/NCase.Application/NCase.Application.csproj", "Core/NCase.Application/"]
COPY ["Core/NCase.Domain/NCase.Domain.csproj", "Core/NCase.Domain/"]
COPY ["Infrastructure/NCase.Infrastructure/NCase.Infrastructure.csproj", "Infrastructure/NCase.Infrastructure/"]
COPY ["Infrastructure/NCase.Persistence/NCase.Persistence.csproj", "Infrastructure/NCase.Persistence/"]
RUN dotnet restore "Presentation/NCase.API/NCase.API.csproj"
COPY . .
WORKDIR "/src/Presentation/NCase.API"
RUN dotnet build "NCase.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NCase.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NCase.API.dll"]