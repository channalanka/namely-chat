FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY namely-chat/*.csproj ./namely/
RUN dotnet restore ./namely

# Copy everything else and build
COPY namely-chat/ ./namely/
RUN dotnet publish ./namely -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/namely/out .
ENTRYPOINT ["dotnet", "namely-chat.dll"]