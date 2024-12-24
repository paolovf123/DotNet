using entityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace entityFramework.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly TareasContext _context;

        public CategoriaService(TareasContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias.ToList();
        }

        public async Task Save(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Categoria categoria)
        {
            var existingCategoria = await _context.Categorias.FindAsync(id);
            if (existingCategoria != null)
            {
                existingCategoria.CategoriaNombre = categoria.CategoriaNombre;
                existingCategoria.CategoriaDescipcion = categoria.CategoriaDescipcion;
                existingCategoria.PesoCategoria = categoria.PesoCategoria;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}