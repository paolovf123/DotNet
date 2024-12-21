using System.ComponentModel.DataAnnotations;
using System.Security;
using System.Text.Json.Serialization;

namespace entityFramework.Models;
public class Categoria
{
    //[Key]
    public Guid CategoriaId { get; set; }
    
    //[Required]
    //[MaxLength(150)]
    public string CategoriaNombre { get; set; }
    public string CategoriaDescipcion { get; set; }
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; }
    public int PesoCategoria { get; set; }
}