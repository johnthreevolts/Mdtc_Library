FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mdtc_library/Mdtc_library.csproj", "Mdtc_library/"]
RUN dotnet restore "Mdtc_library/Mdtc_library.csproj"
COPY . .
WORKDIR "/src/Mdtc_library"
RUN dotnet build "Mdtc_library.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mdtc_library.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mdtc_library.dll"]
