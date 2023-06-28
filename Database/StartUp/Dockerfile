#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/mssql/server:2022-latest

COPY ./Database/StartUp /

CMD /bin/bash ./entrypoint.sh