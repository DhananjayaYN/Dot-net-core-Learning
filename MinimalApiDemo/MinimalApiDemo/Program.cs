using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

// Required for Swagger in Minimal APIs
builder.Services.AddEndpointsApiExplorer();

// Add Swagger services
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Product API endpoints --------------------------------

app.MapGet("/api/products", () =>
{    
    // Sample data - replace with your actual data source
    var products = new[]
    {
        new Product { Id = 1, Name = "Product A", Price = 10.99m },
        new Product { Id = 2, Name = "Product B", Price = 19.99m },
        new Product { Id = 3, Name = "Product C", Price = 5.99m }
    };
    return Results.Ok(products);
})
.WithName("GetProducts");


app.MapPost("/api/products", ([FromBody] Product product) =>
{
    // Basic validation
    if (product == null)
    {
        return Results.BadRequest(new { message = "Product data is required." });
    }

    if (string.IsNullOrWhiteSpace(product.Name))
    {
        return Results.BadRequest(new { message = "Product name is required." });
    }

    if (product.Price <= 0)
    {
        return Results.BadRequest(new { message = "Price must be greater than zero." });
    }

    // Here you would typically add the product to your database
    var newProduct = new Product
    {
        Id = new Random().Next(1000, 9999), // Simulate ID generation
        Name = product.Name,
        Price = product.Price
    };
    return Results.Created($"/api/products/{newProduct.Id}", newProduct);
})
.WithName("AddProduct")
.Produces<Product>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);


app.MapPut("/api/products/{id}", ([FromRoute] int id, [FromBody] Product updatedProduct) =>
{
    // Basic validation
    if (updatedProduct == null)
    {
        return Results.BadRequest(new { message = "Updated product data is required." });
    }

    if (string.IsNullOrWhiteSpace(updatedProduct.Name))
    {
        return Results.BadRequest(new { message = "Product name is required." });
    }

    if (updatedProduct.Price <= 0)
    {
        return Results.BadRequest(new { message = "Price must be greater than zero." });
    }


    // Here you would typically update the product in your database
    var updateProduct = new Product
    {
        Id = id,
        Name = updatedProduct.Name,
        Price = updatedProduct.Price
    };
    return Results.Ok(updateProduct);
})
.WithName("UpdateProduct")
.Produces<Product>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest);

app.MapDelete("/api/products/{id}", ([FromRoute] int id) =>
{
    //basic validation
    if (id <= 0)    {
        return Results.BadRequest(new { message = "Invalid product ID." });
    }

    // Here you would typically delete the product from your database
    return Results.NoContent();
})
.WithName("DeleteProduct")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status400BadRequest);


//--------------------------------------------------------

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
