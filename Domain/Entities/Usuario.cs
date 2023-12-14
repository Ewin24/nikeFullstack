using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? Contraseña { get; set; }

    public int PersonaIdPersona { get; set; }

    public string? Correo { get; set; }

    public string? Celular { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual Persona PersonaIdPersonaNavigation { get; set; } = null!;
}
