# Inventory Management API

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-9.0-green)
![Azure SQL Database](https://img.shields.io/badge/Azure%20SQL-Database-blue)
![License](https://img.shields.io/badge/license-MIT-green)

[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-white.svg)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)

## Overview

**InventoryManagementAPI** is an open-source project designed to provide a simple and efficient inventory management system. Built with **.NET Core 8** and **Entity Framework Core**, it integrates with **Azure SQL Database** to manage stock levels, track purchases, and provide an API for basic inventory operations.

## Metrics

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=bugs)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=coverage)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=MarciovsRocha_mf_imports_api&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=MarciovsRocha_mf_imports_api)


## Features

- **RESTful API** for inventory management
- Full **CRUD** operations for products, categories, connectors, and more
- **Entity Framework Core** for seamless database integration
- **SQL Server** hosted on Azure
- Easily deployable to Azure Web App
- Scalable and ready for production environments

## Table of Contents

1. [Getting Started](#getting-started)
2. [API Endpoints](#api-endpoints)
3. [Database Schema](#database-schema)
4. [Deployment](#deployment)
5. [Contributing](#contributing)
6. [License](#license)

## Getting Started

### Prerequisites

To run this project, you need to have the following installed:

- [.NET Core 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Azure account](https://azure.microsoft.com/) (for deployment)
- [Git](https://git-scm.com/)

### Installation

1. Clone the repository:

```bash
git clone https://github.com/MarciovsRocha/InventoryManagementAPI.git
cd InventoryManagementAPI
```

2. Restore Dependencies

```bash
dotnet restore
```

3. Set up your database connection string in the `appsettings.json` file

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:<your-server>.database.windows.net,1433;Database=<your-database>;User ID=<your-username>;Password=<your-password>;Encrypt=true;"
  }
} 
```

4.[CONTRIBUTING.md](CONTRIBUTING.md) Run the project 

```bash
dotnet run
```

---

Esse `README.md` inclui uma visão geral do projeto, instruções de instalação e configuração, endpoints de API, e orientações sobre contribuição.
