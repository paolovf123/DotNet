namespace entityFramework;



using Microsoft.EntityFrameworkCore;
using entityFramework.Models;


public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId=Guid.Parse("947f788f-c28b-4267-8b6c-f190fb513ca7"), CategoriaNombre="Actividades Pendientes",PesoCategoria=20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("947f788f-c28b-4267-8b6c-f190fb513c02"), CategoriaNombre = "Actividades Personales", PesoCategoria = 50 });
        
        
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.CategoriaNombre).IsRequired().HasMaxLength(100);
            categoria.Property(p => p.CategoriaDescipcion).IsRequired(false);
            categoria.Property(p => p.PesoCategoria);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("947f788f-c28b-4267-8b6c-f190fb513c10"), CategoriaId = Guid.Parse("947f788f-c28b-4267-8b6c-f190fb513ca7"), TareaPrioridad = Prioridad.Media, TareaTitulo = "Pago de la U" });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("947f788f-c28b-4267-8b6c-f190fb513c11"), CategoriaId = Guid.Parse("947f788f-c28b-4267-8b6c-f190fb513c02"), TareaPrioridad = Prioridad.Alta, TareaTitulo = "Pago del cuarto" });
        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.TareaTitulo).IsRequired().HasMaxLength(100);
            tarea.Property(p => p.TareaDescripcion).IsRequired(false);
            tarea.Property(p => p.TareaPrioridad);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p=>p.Resumen);
            tarea.Property(p => p.TareaGosu);


            tarea.HasData(tareasInit);
        });
     }
}
