using System;
using System.Collections.Generic;

namespace MitosAPI.Models;

public partial class Dios
{
    public int IdDios { get; set; }

    public string? Nombre { get; set; }

    public string? Poder { get; set; }

    public int? IdMitologia { get; set; }

    public string? Afiliacion { get; set; }

    public string? Hogar { get; set; }

    public string? Posesiones { get; set; }

    public string? UrlImagen { get; set; }

    public string? NombreImagen { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Mitologia? oMitologia { get; set; }
}
