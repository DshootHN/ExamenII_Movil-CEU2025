using System.ComponentModel.DataAnnotations;

namespace AppWebAPI.Models;

public class Tareas
{
    [Key]
    public Guid Id { get; set; }
    public string NombreTarea { get; set; }
    public string Descripcion { get; set; }
    public DateTime CreatedAt { get; set; }
}