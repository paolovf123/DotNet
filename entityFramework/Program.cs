
using System.Threading;
using entityFramework;
using entityFramework.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(Db => Db.UseInMemoryDatabase("TareasDb"));
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

//tarea
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria));
});
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.UtcNow;
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    if(tareaActual != null){
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.TareaTitulo = tarea.TareaTitulo;
        tareaActual.TareaPrioridad = tarea.TareaPrioridad;
        tareaActual.TareaDescripcion = tarea.TareaDescripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});
app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual != null) { 
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});




//categoria
app.MapGet("/api/categorias", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Categorias);
});
app.MapPost("/api/categorias", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria) =>
{
    categoria.CategoriaId = Guid.NewGuid();
    await dbContext.AddAsync(categoria);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.MapPut("/api/categorias/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria, [FromRoute]Guid id) =>
{
    var categoriaActual = dbContext.Categorias.Find(id);
    if (categoriaActual != null)
    {
        categoriaActual.CategoriaNombre = categoria.CategoriaNombre;
        categoriaActual.CategoriaDescipcion = categoria.CategoriaDescipcion;
        categoriaActual.PesoCategoria = categoria.PesoCategoria;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});
app.MapDelete("/api/categorias/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    var categoriaActual = dbContext.Categorias.Find(id);
    if (categoriaActual != null)
    {
        dbContext.Remove(categoriaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});
app.Run();

