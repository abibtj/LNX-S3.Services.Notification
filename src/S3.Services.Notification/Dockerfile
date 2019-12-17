FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
WORKDIR /app
COPY ./bin/Release/netcoreapp2.2 .
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 80
ENTRYPOINT dotnet S3.Services.Notification.dll

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#WORKDIR /src
#COPY ["src/S3.Services.Notification/S3.Services.Notification.csproj", "src/S3.Services.Notification/"]
#RUN dotnet restore "src/S3.Services.Notification/S3.Services.Notification.csproj"
#COPY . .
#WORKDIR "/src/src/S3.Services.Notification"
#RUN dotnet build "S3.Services.Notification.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "S3.Services.Notification.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "S3.Services.Notification.dll"]