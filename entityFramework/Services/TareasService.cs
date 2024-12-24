using entityFramework.Models;
namespace entityFramework.Services;

public class TareasService : ITareasService
{
    TareasContext context;
    public TareasService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }
    public async Task Save(Tarea tarea)
    {
        context.Tareas.Add(tarea);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.TareaTitulo = tarea.TareaTitulo;
            tareaActual.TareaDescripcion = tarea.TareaDescripcion;
            tareaActual.TareaPrioridad = tarea.TareaPrioridad;
            tareaActual.TareaGosu = tarea.TareaGosu;
            tareaActual.CategoriaId = tarea.CategoriaId;
            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}
public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}