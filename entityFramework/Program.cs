using entityFramework;
using entityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using entityFramework.Services;
using entityFramework.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));

// Configuración de servicios
builder.Services.AddScoped<ITareasService, TareasService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

// Añadir controladores
builder.Services.AddControllers();

// Configuración de CORS (opcional)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Middleware de manejo de excepciones (opcional)
app.UseExceptionHandler("/error");

// Configuración de CORS (opcional)
app.UseCors();

// Configuración de enrutamiento
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", () => "Hello World!");
});

app.Run();