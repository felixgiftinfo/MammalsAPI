
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj /app
RUN dotnet restore

# copy everything else and build app
COPY . /app
WORKDIR /app/
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app


COPY --from=build app/out ./
EXPOSE 4000
EXPOSE 4100
EXPOSE 4200
ENTRYPOINT ["dotnet", "AnimalService.dll"]