using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int? Existencias { get; set; }

    public DateOnly? FechaActualizacion { get; set; }

    public int ProductoIdProducto { get; set; }

    public virtual Producto ProductoIdProductoNavigation { get; set; } = null!;
}
