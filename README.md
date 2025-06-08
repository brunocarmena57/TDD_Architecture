# TDD Architecture .NET API 📚

## Overview 
The **TDD Architecture .NET API** is a structured example demonstrating the implementation of TDD Architecture using .NET Core 8. This project serves as a resource for developers on understanding and applying TDD Architecture through best practices and development patterns.

This repository showcases:

* Separation of Concerns (SoC) via TDD Architecture

* Code First Development with Database Migrations

* Effective Utilization of the Repository Pattern, Unit of Work, and Singleton Design Pattern

* Automated Unit Testing with xUnit Framework

* JSON Web Tokens (JWT) based Authentication and Authorization

## Project Structure 🏗️
```
TDD_Architecture.Api
 ├── Config
 │   ├── MappingConfig
 ├── Controllers
 │   ├── V2
 ├── Middlewares
 ├── Properties

TDD_Architecture.Application
 ├── Mappings
 ├── Models
 │   ├── Http
 ├── Services
 │   ├── Login
 │   │   ├── Interfaces
 │   ├── Products
 │   │   ├── Interfaces
 │   ├── Sales
 │   │   ├── Interfaces
 │   ├── Users
 │   │   ├── Interfaces
 ├── ViewModels
 │   ├── Products
 │   ├── Sales
 │   ├── Users

TDD_Architecture.Domain
 ├── Entities
 │   ├── Base
 │   ├── Products
 │   ├── Sales
 │   ├── Users
 ├── Enums
 ├── Interfaces

TDD_Architecture.Infra
 ├── Authentication
 ├── Data
 │   ├── Context
 │   ├── EntitiesConfiguration
 │   │   ├── Products
 │   │   ├── Sales
 │   │   ├── Users
 ├── Repositories
 │   ├── Products
 │   ├── Sales
 │   ├── Users
 ├── Singletons
 │   ├── Cache
 │   │   ├── Interfaces
 │   ├── Logger
 │   │   ├── Interfaces

TDD_Architecture.Tests
 ├── Controllers
 │   ├── Products
 │   ├── Sales
 │   ├── Users
 │   ├── Login
 ├── Services
 │   ├── Products
 │   ├── Sales
 │   ├── Users
 ├── Repositories
 │   ├── Products
 │   ├── Sales
 │   ├── Users
```

## Getting Started 🚀

Make sure you have the following installed:
- [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation ⚙️
```bash
# Clone the repository
git clone https://github.com/brunocarmena57/TDD_Architecture.git
cd TDD_Architecture
```

### Configuration ⚙️
Before running the application, update the **database connection string** in:
- `appsettings.json`
- `appsettings.Development.json`

Example:
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=localhost\\SQLEXPRESS;Initial Catalog=TDD_Architecture;Integrated Security=True;TrustServerCertificate=True"
}
```

### Running it ▶️
```bash
# Execute the API project
dotnet run --project TDD_Architecture.Api
```

## Authentication & Initial Token Usage 🔑
To get an authentication token, utilize the following credentials  and use the login endpoint:
- **Email:** `usertest@test.com.br`

## Features & Modules 🌟
This application includes:

* **Sales Registration (Adhering to Specified Business Logic)**  
* **User Registration (Including Address and Contact Information)**   
* **Product Management (Featuring Defined Product Categories)**   

## Technologies Utilized 💻
- **.NET Core 8** 
- **Entity Framework Core**
- **SQL Server** 
- **AutoMapper**
- **xUnit (Unit Testing Framework)**
- **JWT Authentication**
- **Singleton, Repository and Service Layer Pattern**


