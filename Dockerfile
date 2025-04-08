# For .NET Core Backend
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["backend/BackendApp/BackendApp.csproj", "backend/BackendApp/"]
RUN dotnet restore "backend/BackendApp/BackendApp.csproj"
COPY . .
WORKDIR "/src/backend/BackendApp"
RUN dotnet build "BackendApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendApp.dll"]

# For React Frontend

FROM node:18 as build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

# Serve with NGINX
FROM nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

