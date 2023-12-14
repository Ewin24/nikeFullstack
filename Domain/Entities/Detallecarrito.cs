using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Detallecarrito : BaseEntity
{
    // public int IdDetalleCarrito { get; set; }

    public int? Cantidad { get; set; }

    public int CarritoIdCarrito { get; set; }

    public int ProductoIdProducto { get; set; }

    public virtual Carrito CarritoIdCarritoNavigation { get; set; } = null!;

    public virtual Producto ProductoIdProductoNavigation { get; set; } = null!;
}
