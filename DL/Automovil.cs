using System;
using System.Collections.Generic;

namespace DL;

public partial class Automovil
{
    public int IdAutomovil { get; set; }

    public string? Placa { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
