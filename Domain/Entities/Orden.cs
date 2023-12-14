using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Orden
{
    public int IdOrden { get; set; }

    public DateOnly? FechaOrden { get; set; }

    public double? Total { get; set; }

    public int UsuarioIdusuario { get; set; }

    public virtual ICollection<Detalleorden> Detalleordens { get; set; } = new List<Detalleorden>();

    public virtual Usuario UsuarioIdusuarioNavigation { get; set; } = null!;
}
