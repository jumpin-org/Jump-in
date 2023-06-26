#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Authentication/Authentication.API/JumpIn.Authentication.API.csproj", "Services/Authentication/Authentication.API/"]
RUN dotnet restore "Services/Authentication/Authentication.API/JumpIn.Authentication.API.csproj"
COPY . .
WORKDIR "/src/Services/Authentication/Authentication.API"
RUN dotnet build "JumpIn.Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JumpIn.Authentication.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JumpIn.Authentication.API.dll"]