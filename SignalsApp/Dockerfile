FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SignalsApp/SignalsApp.csproj", "SignalsApp/"]
RUN dotnet restore "SignalsApp/SignalsApp.csproj"
COPY . .
WORKDIR "/src/SignalsApp"
RUN dotnet build "SignalsApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalsApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalsApp.dll"]
