FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MS1.csproj", ""]
RUN dotnet restore "./MS1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MS1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MS1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MS1.dll"]