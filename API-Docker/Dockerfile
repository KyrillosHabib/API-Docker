# 🏗 Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["API-Docker.csproj", "./"]
RUN dotnet restore "./API-Docker.csproj"
COPY . .
RUN dotnet publish "./API-Docker.csproj" -c Release -o /app/publish

# 🚀 Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# 👇 Add cert
COPY ./https/aspnetapp.pfx /https/aspnetapp.pfx

# 👇 Pass cert via ENV
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=K_aziz@1998

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "API-Docker.dll"]
