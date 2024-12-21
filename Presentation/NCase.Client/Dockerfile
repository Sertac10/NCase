#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/NCase.Client/NCase.Client.csproj", "Presentation/NCase.Client/"]
COPY ["Core/NCase.Application/NCase.Application.csproj", "Core/NCase.Application/"]
COPY ["Core/NCase.Domain/NCase.Domain.csproj", "Core/NCase.Domain/"]
RUN dotnet restore "Presentation/NCase.Client/NCase.Client.csproj"
COPY . .
WORKDIR "/src/Presentation/NCase.Client"
RUN dotnet build "NCase.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NCase.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NCase.Client.dll"]