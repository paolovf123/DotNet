using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entityFramework.Models;
public class Tarea
{
    [Key]
    public Guid TareaId { get; set; }

    [ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }

    [Required]
    [MaxLength(255)]
    public string TareaTitulo{ get; set; }
    public string TareaDescripcion { get; set; }
    public Prioridad TareaPrioridad { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual Categoria Categoria { get; set; }

    [NotMapped]
    public string Resumen {  get; set; }
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}