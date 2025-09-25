FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BlazorApp1.csproj", "./"]
RUN dotnet restore
COPY . .
RUN dotnet build "BlazorApp1.csproj" -c Release -o /app/build
RUN dotnet publish "BlazorApp1.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "BlazorApp1.dll"]