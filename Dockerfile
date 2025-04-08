### ---------- BACKEND ---------- ###
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS backend-base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS backend-build
WORKDIR /src
COPY ["backend/BackendApp/BackendApp.csproj", "backend/BackendApp/"]
RUN dotnet restore "backend/BackendApp/BackendApp.csproj"
COPY backend/BackendApp/ backend/BackendApp/
WORKDIR "/src/backend/BackendApp"
RUN dotnet build "BackendApp.csproj" -c Release -o /app/build

FROM backend-build AS backend-publish
RUN dotnet publish "BackendApp.csproj" -c Release -o /app/publish

FROM backend-base AS backend-final
WORKDIR /app
COPY --from=backend-publish /app/publish .
ENTRYPOINT ["dotnet", "BackendApp.dll"]

### ---------- FRONTEND ---------- ###
FROM node:18 AS frontend-build
WORKDIR /app
COPY frontend/package.json ./
COPY frontend ./
RUN npm install
RUN npm run build

### ---------- NGINX SERVE ---------- ###
FROM nginx:alpine AS frontend-final
COPY --from=frontend-build /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

