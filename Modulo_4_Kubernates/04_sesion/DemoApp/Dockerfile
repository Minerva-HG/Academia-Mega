FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY DemoApp.csproj .
RUN dotnet restore DemoApp.csproj
COPY . .
RUN dotnet publish DemoApp.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT [ "dotnet", "DemoApp.dll" ]
