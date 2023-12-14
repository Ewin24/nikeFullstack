using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Detalleorden : BaseEntity
{
    // public int IdDetalleOrden { get; set; }

    public int? Cantidad { get; set; }

    public double? PrecioUnitario { get; set; }

    public int OrdenIdOrden { get; set; }

    public int ProductoIdProducto { get; set; }

    public virtual Orden OrdenIdOrdenNavigation { get; set; } = null!;

    public virtual Producto ProductoIdProductoNavigation { get; set; } = null!;
}
