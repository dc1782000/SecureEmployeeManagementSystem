# 🏢 Project Setup & Architecture Guide

This repository contains a complete Employee Management System built using **ASP.NET Core Web API**, **SQL Server**, **Repository Pattern**, and **Clean Architecture** principles.

---

# 📁 Repository Structure

## frontend/

Contains the complete Frontend User Interface application.

### Responsibilities

- Employee Management UI
- Authentication Screens
- Dashboard
- API Integration
- Client-side Validation

---

## src/

Contains the Backend solution organized using Clean Architecture.

### Domain (Class Library)

The core layer of the application.

#### Responsibilities

- Entity Models
- Base Entities
- Domain Rules
- Domain Exceptions

**Dependency Rule:** No external dependencies.

---

### Application (Class Library)

Contains application-level business logic and contracts.

#### Responsibilities

- DTOs (Data Transfer Objects)
- Repository Interfaces
- Service Interfaces
- Application Services
- Validation Rules
- Business Use Cases

**Dependency Rule:** Depends only on Domain.

---

### Persistence (Class Library)

Responsible for database-related operations.

#### Responsibilities

- Entity Framework Core DbContext
- Database Configurations
- EF Core Migrations
- Database Seeding
- SQL Server Integration

**Dependency Rule:** Depends on Domain and Application.

---

### Infrastructure (Class Library)

Responsible for external services and technical implementations.

#### Responsibilities

- Repository Pattern Implementations
- JWT Token Generation
- Password Hashing
- Security Services
- External Service Integrations

**Dependency Rule:** Depends on Domain and Application.

---

### SecureEmployeeManagementSystem.API (Web API)

The entry point of the backend application.

#### Responsibilities

- Controllers
- Authentication & Authorization Configuration
- Dependency Injection
- Middleware Configuration
- Swagger/OpenAPI
- Request & Response Handling

**Dependency Rule:** References Application, Persistence, and Infrastructure.

---

## tests/

Contains automated testing projects.

---

## docs/

Contains project documentation.


---

# 🚀 Quick Setup Instructions

Follow the steps below to run the application locally.

---

## 📌 Step 1: Clone Repository

Open Terminal and run:

```bash
git clone <https://github.com/dc1782000/SecureEmployeeManagementSystem.git>

cd SecureEmployeeManagementSystem
```

---

## 📌 Step 2: Database Setup

### Option 1 – Using SQL Script (Recommended)

1. Create a new SQL Server database:

```sql
SecureEmployeeManagementDb
```

2. Locate the exported `.sql` file provided in the repository.

3. Open the script in SQL Server Management Studio (SSMS).

4. Execute the script (F5).

The script will automatically:

- Create all required tables
- Create relationships
- Insert sample data
- Insert default users

---

### Option 2 – Using Entity Framework Migrations

Run the following commands from the project root:

```bash
dotnet ef database update \
--project src/SecureEmployeeManagementSystem.Persistence \
--startup-project src/SecureEmployeeManagementSystem.API
```

---

## 📌 Step 3: Configure Database Connection

Open:

```text
src/SecureEmployeeManagementSystem.API/appsettings.Development.json
```

Update the connection string if required:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SecureEmployeeManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---

## 📌 Step 4: Run the Backend API

From the project root:

```bash
dotnet restore

dotnet build

dotnet run --project src/SecureEmployeeManagementSystem.API
```

Once the API starts successfully, open Swagger in your browser:

```text
https://localhost:xxxx/swagger
```

or

```text
http://localhost:xxxx/swagger
```

---

## 📌 Step 5: Run the Frontend Application

1. Open the `frontend` folder in Visual Studio Code.

2. Install the **Live Server** extension.

3. Right-click:

```text
index.html
```

4. Select:

```text
Open with Live Server
```

The application will open automatically in your browser.

Example:

```text
http://localhost:5500
```

---

# 🔐 Authentication

The application uses:

- JWT Authentication
- Role-Based Authorization
- Admin and User Roles
- Secure Password Hashing

---

# 🔑 Default Users For Testing

The system includes pre-seeded users for testing purposes.

## 👨‍💼 Admin User

| Field | Value |
|---------|---------|
| Username | Morris |
| Password | Admin@123 |
| Role | Admin |

---

## 👤 Normal User

| Field | Value |
|---------|---------|
| Username | dc |
| Password | Admin@123 |
| Role | User |

---

# ⚠️ Important Notes

- Usernames and passwords are case-sensitive.
- SQL Server must be running before starting the API.
- Ensure the database connection string is correctly configured.
- Run the SQL script or EF migrations before launching the application.
- Swagger can be used to test all available API endpoints.

---

# 🛠️ Technology Stack

## Backend

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Repository Pattern
- Clean Architecture

## Frontend

- HTML
- CSS
- JavaScript

## Development Tools

- JetBrains Rider
- Visual Studio Code
- SQL Server Management Studio (SSMS)
- Docker 

---

# 📄 License

This project is intended for assessment, learning, and demonstration purposes.
