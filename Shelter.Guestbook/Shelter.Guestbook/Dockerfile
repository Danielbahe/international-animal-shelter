#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Shelter.Guestbook/Shelter.Guestbook/Shelter.Guestbook.Api.csproj", "Shelter.Guestbook/"]
COPY ["Shelter.Guestbook/Shelter.Infrastructure/Shelter.Infrastructure.csproj", "Shelter.Infrastructure/"]
COPY ["Shelter.Guestbook/Shelter.Guestbook.Domain/Shelter.Guestbook.Domain.csproj", "Shelter.Guestbook.Domain/"]
COPY ["Shelter.Guestbook/Shelter.Guestbook.DataAccess/Shelter.Guestbook.DataAccess.csproj", "Shelter.Guestbook.DataAccess/"]
RUN dotnet restore "Shelter.Guestbook/Shelter.Guestbook.Api.csproj"

COPY . .

WORKDIR "/src/Shelter.Guestbook/Shelter.Guestbook"
RUN dotnet build "Shelter.Guestbook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shelter.Guestbook.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shelter.Guestbook.Api.dll"]