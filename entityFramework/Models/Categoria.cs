using System.ComponentModel.DataAnnotations;
using System.Security;

namespace entityFramework.Models;
public class Categoria
{
    [Key]
    public Guid CategoriaId { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string CategoriaNombre { get; set; }
    public string CategoriaDescipcion { get; set; }
    public virtual ICollection<Tarea> Tareas { get; set; }
}