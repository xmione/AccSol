#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5154
EXPOSE 7010

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
# Metadata indicating an image maintainer.
LABEL maintainer="solomiosisante@gmail.com"
ARG BUILD_CONFIGURATION=Release

ENV ASPNETCORE_URLS="http://+" 
ENV ASPNETCORE_HTTP_PORT=5154
ENV ASPNETCORE_HTTPS_PORT=7010
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="P@ssw0rd123" 
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/src/certs/AccSol.pfx

WORKDIR /src
COPY ["certs/AccSol.pfx", "certs/"]
COPY ["AccSol/AccSol.csproj", "AccSol/"]
COPY ["AccSol.EF/AccSol.EF.csproj", "AccSol.EF/"]
RUN dotnet restore "./AccSol/./AccSol.csproj"
COPY . .
WORKDIR "/src/AccSol"
RUN dotnet build "./AccSol.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AccSol.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccSol.dll"]