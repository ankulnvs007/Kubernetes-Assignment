using Microsoft.EntityFrameworkCore;
using Product.API.Data.DbContexts;
using Product.API.Repositories.IRepositories;
using Product.API.Repositories;
using Product.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseInMemoryDatabase("ProductInMemoryDb");
});

// Add ProductRepository to DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Ensure database is created and seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    context.Database.EnsureCreated();

    // Seed data if necessary
    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new ProductModel { ProductId = 1, ProductName = "Smartphone", Description = "Latest smartphone with high-end specs", Category = "Electronics", Price = 699.99M },
            new ProductModel { ProductId = 2, ProductName = "Laptop", Description = "Powerful laptop for work and gaming", Category = "Computers", Price = 1199.99M },
            new ProductModel { ProductId = 3, ProductName = "Headphones", Description = "Noise-cancelling over-ear headphones", Category = "Accessories", Price = 299.99M }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Enable CORS
app.UseCors("AllowAll");

app.MapGet("/", () => "Product API is running.");

app.MapControllers();

app.Run();
