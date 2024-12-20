
using entityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(Db => Db.UseInMemoryDatabase("TareasDb"));
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));
var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Ya tamos en postgres" + !dbContext.Database.IsInMemory());
});
app.Run();

