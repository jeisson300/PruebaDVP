using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaDVP.Model;

public partial class Usuarios
{
    [Key, Required]
    public required string Identificador { get; set; }

    public required string Usuario { get; set; }

    public required string Password { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now; 
}
