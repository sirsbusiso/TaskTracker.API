# TaskTracker.API

LexisNexis Assessment : Task Tracker

Solution built in dotnet core 8 and the main functionality is to track task.

The architecture approach used is DDD with traditional repository pattern.

Clean soliuton that adhere to SOLID principle to promote clease code and easy maintenance

Did I encouter any issue that I needed to solve quickly?

- No, no major issue encounted fortunately except for normal build issues

Unit testing included?

- Yes, I included two test methods as instructed, I could add more.

Branching approach used?

- I used only master since it is a small solition but in the ideal world the approach will be branching from master to a feature and pull request to a release branch that is also from master and run the pipeline using a release and merge back to master once the feature is tested and stable on production environment.

How to run the solution?

- Since I used the in memory database and seeding there is no required actions to do except for running the project and test if needed.

TaskTracker Solution

1. Overview

The TaskTracker solution is a multi-layered .NET 8 application with:

API Layer: TaskTracker.API

Application Layer: Business logic, DTOs, services

Domain Layer: Entities and core domain models

Infrastructure Layer: Database access and repositories

Tests: Unit tests for the application

Additional features:

Docker support for containerization

CI/CD using GitHub Actions to build and publish Docker images

2. Solution Structure
   TaskTracker.sln
   │
   ├── TaskTracker.API # API Layer
   │ ├── Controllers # API endpoints
   │ ├── Properties
   │ ├── appsettings.json
   │ ├── Dockerfile
   │ └── Program.cs # Startup and DI
   │
   ├── TaskTracker.Application # Application Layer
   │ ├── DTOs # Data transfer objects
   │ ├── Exceptions # Custom exceptions
   │ ├── Interfaces # Service interfaces
   │ ├── Middleware # Logging, error handling
   │ ├── Model # Domain models if needed
   │ ├── Profiles # AutoMapper profiles
   │ └── Services # Business logic implementations
   │
   ├── TaskTracker.Domain # Domain Layer
   │ └── Entities # Core entities (e.g., TaskEntity)
   │
   ├── TaskTracker.Infrastructure # Infrastructure Layer
   │ ├── Data # Database context
   │ ├── Interfaces # Repository interfaces
   │ └── Repository # Repository implementations
   │
   └── TaskTracker.Tests # Unit/Integration Tests
   └── TaskTrackerTests

| Layer              | Responsibility                                                         |
| ------------------ | ---------------------------------------------------------------------- |
| **API**            | Handles HTTP requests and responses, routing, controllers, middleware. |
| **Application**    | Business logic, DTO mapping, services, validation, middleware.         |
| **Domain**         | Core domain entities and models.                                       |
| **Infrastructure** | Database access, repositories, and external service integrations.      |
| **Tests**          | Unit and integration tests for application and domain logic.           |

4. CI/CD with GitHub Actions

Build & Test: Runs .NET 8 build and test commands.

Docker: Builds a Docker image for the API.

Push: Pushes Docker image to Docker Hub using secrets (DOCKER_USERNAME, DOCKER_PASSWORD).

Workflow Example: .github/workflows/docker-build.yml
