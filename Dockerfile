FROM mcr.microsoft.com/dotnet/aspnet:8.0.2-alpine3.18 AS base
WORKDIR /app

##COPY Taller1.Infrastructure.Console/bin/Debug/net8.0/  .
##COPY Taller1.Infrastructure.API/bin/Debug/net8.0/  .
 
ENV TZ=America/Bogota
RUN sh -c "ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone"
ENV ASPNETCORE_URLS=http://+:80