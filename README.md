# EmployeeManagement
![workflow-status](https://github.com/gldnpz17/EmployeeManagement/actions/workflows/dotnet.yml/badge.svg) ![workflow-status](https://github.com/gldnpz17/EmployeeManagement/actions/workflows/push-to-docker-hub.yml/badge.svg)

An assignment for DTETI UGM's software architecture course.

Demo: https://employeemanagement.gldnpz.com

Group members:
1. Firdaus Bisma Suryakusuma (NIM: 19/444051/TK/49247)
2. Syafiq Muhammad Alaudin (NIM: 19/444073/TK/49269)

## Project Structure
```
base directory
|-- .github
|   |-- workflows
|       |-- dotnet.yml (Run unit tests for the backend.)
|       |-- push-to-docker-hub.yml (Builds a docker image and pushes it to docker hub to later be deployed automatically to my server on azure.)
|-- EmployeeManagement
|   |-- Common (Some common utility classes.)
|   |-- Controllers (Controllers containing the API endpoints.)
|   |-- Models (The models to be serialized to json.)
|   |-- client-app (The client app made with React.)
|   |-- Dockerfile (The dockerfile used to build the container image.)
|   |-- Startup.cs (Middleware and dependency injection configurations.)
|-- Entities
|   |-- DomainModel (The entities layer of the clean architecture and the domain model of the application.)
|-- Infrastructure
|   |-- DomainServiceImplementation (Concrete implementations of the services required by the domain model.)
|   |-- EFCoreInMemory (In-memory database used for unit testing and a placeholder during development.)
|   |-- EFCorePostgres (Postgres implementation of the data access layer.)
|-- Unit tests
|   |-- ApplicationUnitTests (Unit tests for the use-cases layer.)
|   |-- DomainModelUnitTests (Unit tests for the domain model.)
|-- UseCases
    |-- Application (The use cases layer of the clean architecture.)
        |-- Common (Some common utlity classes.)
        |-- Employees (Commands and queries related to employees.)
        |-- Bootstrapper.cs (Dependency injection configuration and a class for retrieving the use cases mediator.)
```

## REST API Documentation
A swagger documentation could be accessed by accessing `/swagger` in development mode.
### Adding a new employee
#### Request
Endpoint: `POST /api/employees`

Body:
```
{
  "name": "Alice",
  "position": "Manager"
}
```
#### Response
Status: `201 Created`

Body:
```
{
  "employeeId": "f5218ee4-9476-4613-9c93-5d272e22ae62"
}
```

### Listing all employees
#### Request
Endpoint: `GET /api/employees`
#### Response
Status: `200 OK`

Body:
```
[
  {
    "employeeId": "f5218ee4-9476-4613-9c93-5d272e22ae62",
    "name": "Alice",
    "position": "Manager"
  },
  {
    "employeeId": "b93b0b27-6b74-482f-ad5c-bb159b22fcb5",
    "name": "Bob",
    "position": "Staff"
  }
]
```

### Fetching a detailed information on an employee
#### Request
Endpoint: `GET /api/employees/{id}`
#### Response
Status: `200 OK`

Body:
```
{
  "employeeId": "f5218ee4-9476-4613-9c93-5d272e22ae62",
  "name": "Alice",
  "position": "CTO",
  "editHistories": [
    {
      "timestamp": "2021-05-02T06:53:15.7170782Z",
      "name": "Alice",
      "position": "Manager"
    },
    {
      "timestamp": "2021-05-02T06:58:17.2925508Z",
      "name": "Alice",
      "position": "CTO"
    }
  ]
}
```

### Updating an employee's data
#### Request
Endpoint: `PUT /api/employees/{id}`

Body:
```
{
  "name": "Alice",
  "position": "CTO"
}
```
#### Response
Status: `200 OK`

### Removing an employee
#### Request
Endpoint: `DELETE /api/employees/{id}`
#### Response
Status: `200 OK`

## Environment Variables
* `ASPNETCORE_ENVIRONMENT`: `Production` for production mode or `Development` for development mode.
* `DATABASE_TYPE`: `InMemory` to use the in-memory database or `PostgreSQL` to use a postgres database. Could only be used in production mode.
* `DATABASE_CONNECTION_STRING`: The database connection string used to connect to a production database.
* `PGDB_CONNECTION_STRING`: The connection string used to generate database migrations.
