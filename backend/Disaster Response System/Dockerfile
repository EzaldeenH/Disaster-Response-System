FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS base

# ICU for full globalization support (dates, cultures, etc.)
RUN apk add --no-cache icu-libs

# Disable the invariant mode (set in base image)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_URLS=http://+:80

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Disaster Response System/Disaster Response System.csproj", "Disaster Response System/"]
RUN dotnet restore "Disaster Response System/Disaster Response System.csproj"

COPY . .
WORKDIR "/src/Disaster Response System"
RUN dotnet build "./Disaster Response System.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Disaster Response System.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Disaster Response System.dll"]
