#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Kindred.Guestbook/Kindred.Guestbook/Kindred.Guestbook.Api.csproj", "Kindred.Guestbook/"]
COPY ["Kindred.Guestbook/Kindred.Infrastructure/Kindred.Infrastructure.csproj", "Kindred.Infrastructure/"]
COPY ["Kindred.Guestbook/Kindred.Guestbook.Domain/Kindred.Guestbook.Domain.csproj", "Kindred.Guestbook.Domain/"]
COPY ["Kindred.Guestbook/Kindred.Guestbook.DataAccess/Kindred.Guestbook.DataAccess.csproj", "Kindred.Guestbook.DataAccess/"]
RUN dotnet restore "Kindred.Guestbook/Kindred.Guestbook.Api.csproj"

COPY . .

WORKDIR "/src/Kindred.Guestbook/Kindred.Guestbook"
RUN dotnet build "Kindred.Guestbook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kindred.Guestbook.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kindred.Guestbook.Api.dll"]