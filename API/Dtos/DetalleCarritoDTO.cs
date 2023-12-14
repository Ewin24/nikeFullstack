using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace API.Dtos
{
    public class DetalleCarritoDTO
    {
        public int Id { get; set; }

        public int? Cantidad { get; set; }

        public int CarritoIdCarrito { get; set; }

        public int ProductoIdProducto { get; set; }
    }
}