using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace API.Dtos
{
    public class InventarioDTO
    {
        public int Id { get; set; }

        public int? Existencias { get; set; }

        public DateOnly? FechaActualizacion { get; set; }

        public int ProductoIdProducto { get; set; }

        public virtual Producto ProductoIdProductoNavigation { get; set; } = null!;
    }
}