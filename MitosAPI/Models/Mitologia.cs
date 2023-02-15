using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MitosAPI.Models;

public partial class Mitologia
{
    public int IdMitologia { get; set; }

    public string? Descripcion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Dios> Dios { get; } = new List<Dios>();
}
