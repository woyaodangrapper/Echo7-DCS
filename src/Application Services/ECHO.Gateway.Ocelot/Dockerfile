#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#
ENV ASPNETCORE_ENVIRONMENT Production
#ÉèÖÃASPNETCORE_ENVIRONMENT
#ENV ASPNETCORE_ENVIRONMENT Development
#ENV ASPNETCORE_ENVIRONMENT Staging

#skywalking·þÎñ×¢²á 
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=SkyAPM.Agent.AspNetCore
ENV TZ Asia/Shanghai
#

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
#
COPY ["build/common.props", "build/"]
COPY ["build/version.props", "build/"]
#
#
COPY ["src/Application Services/ECHO.Gateway.Ocelot/appsettings.development.json", "src/Application Services/ECHO.Gateway.Ocelot/"]
COPY ["src/Application Services/ECHO.Gateway.Ocelot/appsettings.production.json", "src/Application Services/ECHO.Gateway.Ocelot/"]
COPY ["src/Application Services/ECHO.Gateway.Ocelot/appsettings.staging.json", "src/Application Services/ECHO.Gateway.Ocelot/"]
COPY ["src/Application Services/ECHO.Gateway.Ocelot/appsettings.test.json", "src/Application Services/ECHO.Gateway.Ocelot/"]
#

#
COPY ["src/Application Services/ECHO.Gateway.Ocelot/Config/ocelot.consul.json", "src/Application Services/ECHO.Gateway.Ocelot/Config/"]
COPY ["src/Application Services/ECHO.Gateway.Ocelot/Config/ocelot.direct.json", "src/Application Services/ECHO.Gateway.Ocelot/Config/"]
COPY ["src/Application Services/ECHO.Gateway.Ocelot/Config/ocelot.fabio.json", "src/Application Services/ECHO.Gateway.Ocelot/Config/"]
#


COPY ["src/Application Services/ECHO.Gateway.Ocelot/ECHO.Gateway.Ocelot.csproj", "src/Application Services/ECHO.Gateway.Ocelot/"]
COPY ["src/Infrastructures/ECHO.Infrastructure.Consul/ECHO.Infrastructure.Consul.csproj", "src/Infrastructures/ECHO.Infrastructure.Consul/"]
COPY ["src/Infrastructures/ECHO.Infrastructure.Core/ECHO.Infrastructure.Core.csproj", "src/Infrastructures/ECHO.Infrastructure.Core/"]
RUN dotnet restore "src/Application Services/ECHO.Gateway.Ocelot/ECHO.Gateway.Ocelot.csproj"
COPY . .
WORKDIR "/src/Application Services/ECHO.Gateway.Ocelot"
RUN dotnet build "ECHO.Gateway.Ocelot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECHO.Gateway.Ocelot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "ECHO.Gateway.Ocelot.dll"]