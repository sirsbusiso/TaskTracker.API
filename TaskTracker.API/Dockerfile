FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Copy solution and all projects
COPY ["TaskTracker.API/TaskTracker.API.csproj", "TaskTracker.API/"]
COPY ["TaskTracker.Application/TaskTracker.Application.csproj", "TaskTracker.Application/"]
COPY ["TaskTracker.Domain/TaskTracker.Domain.csproj", "TaskTracker.Domain/"]
COPY ["TaskTracker.Infrastructure/TaskTracker.Infrastructure.csproj", "TaskTracker.Infrastructure/"]
# Restore NuGet packages
RUN dotnet restore "TaskTracker.API/TaskTracker.API.csproj"
# Copy the full source code
COPY . .
# Build the project
WORKDIR "/src/TaskTracker.API"
RUN dotnet publish -c Release -o /app/publish
# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
# Copy published app from build stage
COPY --from=build /app/publish .
# Set the entry point
ENTRYPOINT ["dotnet", "TaskTracker.API.dll"]