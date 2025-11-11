API-Project TaskTracker.API

Description

This is the backend API built with .NET 8 / ASP.NET Core Web API.
It provides endpoints for managing tasksand other resources with Entity Framework Core for database interactions.

The API uses inMemory database so there is no need to worry about migrations

The data is seeded on model creation, again no need for migrations

Features

RESTful API endpoints

Entity Framework Core for database management

Middleware for logging and error handling

DTOs and AutoMapper for clean data mapping

Swagger / OpenAPI documentation

Environment-specific configuration

Prerequisites

.NET SDK 8.x

Visual Studio 2022+ or VS Code

Database - InMemory database

Installation

# Clone the repository

git clone https://github.com/sirsbusiso/TaskTracker.API.git

# Navigate to project folder

cd TaskTracker.API

# Restore dependencies

dotnet restore

Running The API

# Run the API in development

dotnet run

# The API will be accessible at

https://localhost:44369

Swagger
https://localhost:44369/swagger/index.html
