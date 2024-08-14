FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG PATH_TO_PROJECT_FILE="src/TaskListAPI.csproj"

WORKDIR /src
COPY . .
RUN dotnet restore $PATH_TO_PROJECT_FILE
RUN dotnet build $PATH_TO_PROJECT_FILE -c Release -o /app/build

FROM build AS publish
RUN dotnet publish $PATH_TO_PROJECT_FILE -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskListAPI.dll"]
