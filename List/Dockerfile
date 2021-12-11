FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["List/List.csproj", "List/"]
RUN dotnet restore "List/List.csproj"
COPY . .
WORKDIR "/src/List"
RUN dotnet build "List.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "List.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "List.dll"]
