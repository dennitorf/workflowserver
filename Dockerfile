#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/Cudataware.WorkflowServer.WebApi/Cudataware.WorkflowServer.WebApi.csproj", "Src/Cudataware.WorkflowServer.WebApi/"]
COPY ["Src/Cudataware.WorkflowServer.Application/Cudataware.WorkflowServer.Application.csproj", "Src/Cudataware.WorkflowServer.Application/"]
COPY ["Src/Cudataware.WorkflowServer.Persistence/Cudataware.WorkflowServer.Persistence.csproj", "Src/Cudataware.WorkflowServer.Persistence/"]
COPY ["Src/Cudataware.WorkflowServer.Domain/Cudataware.WorkflowServer.Domain.csproj", "Src/Cudataware.WorkflowServer.Domain/"]
COPY ["Src/Cudataware.WorkflowServer.Infrastructure/Cudataware.WorkflowServer.Infrastructure.csproj", "Src/Cudataware.WorkflowServer.Infrastructure/"]
RUN dotnet restore "Src/Cudataware.WorkflowServer.WebApi/Cudataware.WorkflowServer.WebApi.csproj"
COPY . .
WORKDIR "/src/Src/Cudataware.WorkflowServer.WebApi"
RUN dotnet build "Cudataware.WorkflowServer.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cudataware.WorkflowServer.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cudataware.WorkflowServer.WebApi.dll"]