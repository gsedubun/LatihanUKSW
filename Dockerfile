FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY . .
RUN dotnet restore

WORKDIR /app/Latihan.Web
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime
WORKDIR /app
COPY --from=build /app/Latihan.Web/out ./
ENTRYPOINT [ "dotnet","Latihan.Web.dll","--urls","http://0.0.0.0:80" ]
#RUN dotnet restore
#RUN dotnet build 

#EXPOSE 5000

# ENTRYPOINT [ "dotnet","/app/LatihanUKSW/Latihan.Web/bin/Debug/netcoreapp2.1/Latihan.Web.dll","--urls", "http://0.0.0.0:80" ]


# FROM microsoft/dotnet:2.1-sdk AS build
# WORKDIR /app

# # copy csproj and restore as distinct layers
# COPY *.sln .
# COPY aspnetapp/*.csproj ./aspnetapp/
# RUN dotnet restore

# # copy everything else and build app
# COPY aspnetapp/. ./aspnetapp/
# WORKDIR /app/aspnetapp
# RUN dotnet publish -c Release -o out


# FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
# WORKDIR /app
# COPY --from=build /app/aspnetapp/out ./
# ENTRYPOINT ["dotnet", "aspnetapp.dll"]
