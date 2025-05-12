# Ambev Developer Evaluation

This is a .NET 8.0 Web API project for managing sales, customers, products, and branches. The application follows Clean Architecture principles and uses PostgreSQL as the database.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
  - [Environment Setup](#environment-setup)
  - [Database Configuration](#database-configuration)
  - [Running the Application](#running-the-application)
- [API Documentation](#api-documentation)
- [Running Tests](#running-tests)
- [Database Migrations](#database-migrations)
- [Project Structure](#project-structure)
- [Contributing](#contributing)

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (for running PostgreSQL in a container)
- [PostgreSQL](https://www.postgresql.org/download/) (if not using Docker)
- [Git](https://git-scm.com/downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### Environment Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/mouts-ambev.git
   cd mouts-ambev
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

### Database Configuration

The application uses PostgreSQL as the database. You can run it using Docker:

```bash
docker run --name ambev-postgres -e POSTGRES_USER=developer -e POSTGRES_PASSWORD=ev@luAt10n -e POSTGRES_DB=developer_evaluation -p 5432:5432 -d postgres:latest
```

Or update the connection string in `src/Ambev.DeveloperEvaluation.WebApi/appsettings.json` if you have PostgreSQL installed locally:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost:5432;Database=developer_evaluation;User Id=developer;Password=ev@luAt10n;TrustServerCertificate=True"
}
```

### Running the Application

1. Apply database migrations (see [Database Migrations](#database-migrations) section below)

2. Run the application:
   ```bash
   cd src/Ambev.DeveloperEvaluation.WebApi
   dotnet run
   ```

   The API will be available at `https://localhost:5001` and `http://localhost:5000`

## API Documentation

Once the application is running, you can access the Swagger UI at:
- Swagger UI: `https://localhost:5001/swagger`
- Swagger JSON: `https://localhost:5001/swagger/v1/swagger.json`

Available endpoints:
- `GET /api/sales` - Get all sales (with optional filters)
- `GET /api/sales/{id}` - Get a specific sale by ID
- `POST /api/sales` - Create a new sale
- `PUT /api/sales/{id}/cancel` - Cancel a sale

## Running Tests

The solution includes unit and integration tests. To run them:

1. Navigate to the solution directory:
   ```bash
   cd tests/Ambev.DeveloperEvaluation.Unit
   ```

2. Run the unit tests:
   ```bash
   dotnet test
   ```

3. For integration tests (requires a running database):
   ```bash
   cd ../Ambev.DeveloperEvaluation.Integration
   dotnet test
   ```

## Database Migrations

### Applying Migrations

#### Option 1: Using .NET CLI

```bash
cd src/Ambev.DeveloperEvaluation.ORM
dotnet ef database update --startup-project ../Ambev.DeveloperEvaluation.WebApi
```

#### Option 2: Using Package Manager Console

1. Open the solution in Visual Studio
2. Open Package Manager Console
3. Set Default Project to `Ambev.DeveloperEvaluation.ORM`
4. Run:
   ```
   Update-Database
   ```

## Project Structure

```
src/
├── Ambev.DeveloperEvaluation.Application/   # Application layer (use cases, DTOs, validators)
├── Ambev.DeveloperEvaluation.Domain/        # Domain layer (entities, interfaces, business rules)
├── Ambev.DeveloperEvaluation.ORM/           # Data access layer (EF Core, repositories)
│   ├── Migrations/                          # Database migrations
│   └── Repositories/                        # Repository implementations
├── Ambev.DeveloperEvaluation.IoC/           # Dependency injection configuration
└── Ambev.DeveloperEvaluation.WebApi/        # Web API project (controllers, middleware)

tests/
├── Ambev.DeveloperEvaluation.Unit/         # Unit tests
└── Ambev.DeveloperEvaluation.Integration/   # Integration tests
```