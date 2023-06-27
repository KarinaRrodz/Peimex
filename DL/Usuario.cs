using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Username { get; set; }

    public string? Contrasena { get; set; }

    public int? IdAutomovil { get; set; }
    public string Placa { get; set; }

    public virtual Automovil? IdAutomovilNavigation { get; set; }
    
}
