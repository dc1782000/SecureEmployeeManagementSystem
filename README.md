 # 🏢 Project Setup & Architecture Guide

This is a monolithic repository containing both the Frontend application and the Backend API designed using **Clean Architecture** principles.

---

## 📁 Repository Folder Structure

*   **frontend/** ➡️ Contains the complete Frontend user interface application.
*   **src/** ➡️ Contains the Backend solution divided into separate Class Libraries:
    *   **Domain/** (Class Library) ➡️ Core entity models, enterprise business logic, and exceptions (No external dependencies).
    *   **Application/** (Class Library) ➡️ Application business rules, DTOs, CQRS handlers, and interface definitions.
    *   **Infrastructure/** (Class Library) ➡️ Data access layers, Entity Framework DbContext, migrations, and third-party integrations.
    *   **SecureEmployeeManagementSystem.API/** (Web API) ➡️ The entry point of the backend app handling HTTP requests, controllers, and dependency injections.

---

## 🚀 Quick Setup Instructions

Execute the following steps in sequence to get the complete system running locally:

### 📌 Step 1: Clone & Navigate
*   Open your terminal window and run:
*   git clone <YOUR_GITHUB_REPOSITORY_LINK>
    cd SecureEmployeeManagementSystem

### 📌 Step 2: Database Initialization
*   Create a new, blank database in your local SQL Server instance named: **`SecureEmployeeManagementDb`**.
*   Locate the exported database `.sql` script file inside the repository.
*   Open and **Execute (F5)** the script against your new database to build all tables and inject testing data automatically.

### 📌 Step 3: Configure App Settings
*   Navigate to `src/SecureEmployeeManagementSystem.API/appsettings.Development.json`.
*   Verify or update your local database connection string:
```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=SecureEmployeeManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

### 📌 Step 4: Run the Backend API
*   Go to the root directory in your terminal and execute:
```bash
    project start from src folder its clean architecture follow repository pattern 
    dotnet restore
    dotnet run --project src/SecureEmployeeManagementSystem.API
    ```
*   Once successfully started, open your browser and navigate to the local Swagger URL to test endpoints.

### 📌 Step 5: Run the Frontend App
*   Open a new terminal window, navigate to the `frontend/` folder, and start the app:
```bash
 *   open frontend in vs code 
  *  right click on project install extension live server and right click on index.html open with live server
    
    ```
*   Open the local port link displayed in your terminal (e.g., `http://localhost:5500`) to view the working system.

## 🔑 Default Users for Testing

The system comes with pre-seeded users for quick testing.

### 👨‍💼 Admin User
- Username: Morris
- Password: Admin@123

### 👤 Normal User
- Username: dc
- Password: Admin@123

* Remember its always case sensitive
