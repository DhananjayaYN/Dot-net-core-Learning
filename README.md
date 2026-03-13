# ASP.NET Core Learning Journey

This repository contains my learning materials, practice exercises, and mini projects developed while studying the ASP.NET Core framework and modern .NET technologies.

The goal of this repository is to document my progress and hands-on experience with building web applications using ASP.NET Core. It includes experiments, sample implementations, and small projects that help me understand the core concepts of backend and full-stack development in the .NET ecosystem.

## What You Will Find in This Repository

- ASP.NET Core fundamentals and project structure
- Web API development using controller-based architecture
- Minimal APIs for lightweight web services
- Integration with Entity Framework Core for database operations
- Blazor components for interactive web UI development
- Client-side integrations using JavaScript and CSS
- Debugging and testing practice projects

## Purpose of This Repository

- Track my learning progress in ASP.NET Core
- Practice real-world development concepts
- Build small projects to strengthen backend and full-stack development skills
- Create a knowledge base for future reference

## Technologies Used

- ASP.NET Core
- .NET
- Blazor
- Entity Framework Core
- C#
- JavaScript
- HTML / CSS


## Demo Projects

### 1. MyFirstAPP (Controller-Based API)

**MyFirstAPP** is a simple ASP.NET Core Web API project built using the **controller-based architecture**.  
It demonstrates how traditional Web APIs are structured using controllers, routes, and action methods.

**Features**

- Controller-based API structure
- Basic API endpoints for testing
- RESTful API design principles
- Example request/response handling

**Example Endpoints**
- GET /api/product
- POST /api/product
- PUT /api/product/{id}
- DELETE /api/product/{id}

**How to Run**

1. Navigate to the project folder

 ``` bash
 cd MyFirstAPP
  ```

2. Run the project

``` bash
dotnet run
```

3. Open the browser or API testing tool (Postman)


http://localhost:<port>/api/products


### 2. MinimalApiDemo (Minimal API Architecture)

**MinimalApiDemo** demonstrates the **Minimal API architecture** in ASP.NET Core.  
Instead of controllers, all endpoints are defined directly in `Program.cs`, making the application lightweight and easy to understand.

This project also integrates **Swagger** for API documentation and testing.

**Features**

- Minimal API endpoint definitions
- CRUD endpoints for sample product data
- Swagger UI integration for API testing
- Clean and lightweight API design

**Example Endpoints**


- GET /api/products
- POST /api/products
- PUT /api/products/{id}
- DELETE /api/products/{id}


#### Swagger Integration

Swagger is used to automatically generate API documentation and provide an interactive interface for testing endpoints.

##### Required Configuration

In `Program.cs`:

### Swagger Configuration in Program.cs

 ``` csharp 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```
#### How to Run MinimalApiDemo

1. Navigate to the project folder

``` bash
cd MinimalApiDemo
```

2. Add Swagger integration

``` bash
dotnet add package Swashbuckle.AspNetCore
```

3. Run the application

``` bash
dotnet run
```

4. Open Swagger UI in the browser

http://localhost:<port>/swagger

You can use the Swagger interface to test all API endpoints directly from the browser.

## Author

Nimesh Dhananjaya  
Software Engineer | Bachelor of Computer Science – University of Ruhuna
