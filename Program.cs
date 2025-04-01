using Microsoft.EntityFrameworkCore;
using Clase3103.Src.Data;
using Clase3103.Src.Repository;
using Clase3103.Src.Interfaces;
using Clase3103.Src.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=database.db"));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStoreRespository, StoreRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Crear Scope para la Base de datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();

    // Migraciones pendientes
    await context.Database.MigrateAsync();

    // Poblar la base de datos con el DataSeeder
    DataSeeder.Initialize(services);
}

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();
