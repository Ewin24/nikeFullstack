using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Carrito
{
    public int IdCarrito { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public int UsuarioIdusuario { get; set; }

    public virtual ICollection<Detallecarrito> Detallecarritos { get; set; } = new List<Detallecarrito>();

    public virtual Usuario UsuarioIdusuarioNavigation { get; set; } = null!;
}
