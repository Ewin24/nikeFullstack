using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Precio { get; set; }

    public int CategoriaIdCategoria { get; set; }

    public virtual Categoria CategoriaIdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Detallecarrito> Detallecarritos { get; set; } = new List<Detallecarrito>();

    public virtual ICollection<Detalleorden> Detalleordens { get; set; } = new List<Detalleorden>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
