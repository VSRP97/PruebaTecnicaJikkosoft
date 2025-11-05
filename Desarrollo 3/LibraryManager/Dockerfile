FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY *.sln .
COPY LibraryManager/*.csproj LibraryManager/
COPY LibraryManager.Application/*.csproj LibraryManager.Application/
COPY LibraryManager.Domain/*.csproj LibraryManager.Domain/
COPY LibraryManager.Infrastructure/*.csproj LibraryManager.Infrastructure/

RUN dotnet restore

COPY . .

RUN dotnet publish LibraryManager/LibraryManager.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "LibraryManager.dll"]