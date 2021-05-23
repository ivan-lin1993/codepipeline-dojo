FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# copy csproj and restore as distinct layers
COPY project/*.csproj ./
# Add customerized nuget config to use private nuget service
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
RUN ./test
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["./project"]
