using System;
using System.Collections.Generic;

namespace PruebaTecnicaDVP.Model;

public partial class Persona
{
    public string Identificador { get; set; } = null!;

    public required string Nombre { get; set; }

    public required string Apellidos { get; set; }

    public int NumeroIdentificacion { get; set; }

    public required string Email { get; set; }

    public int TipoIdentificacion { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public required string IdentificacionTipoIdentificacion { get; set; }

    public required string NombreCompleto { get; set; }
}
