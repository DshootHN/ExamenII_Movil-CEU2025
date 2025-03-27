using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebAPI.Models;
[Table("tareas")]
public class Tareas
{
    [Key]

    [Column("id")]
    public Guid Id { get; set; }
    public string NombreTarea { get; set; }
    public string Descripcion { get; set; }
    public DateTime CreatedAt { get; set; }
}