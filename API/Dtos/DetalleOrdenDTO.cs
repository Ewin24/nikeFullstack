using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace API.Dtos
{
    public class DetalleOrdenDTO
    {
        public int Id { get; set; }

        public int? Cantidad { get; set; }

        public double? PrecioUnitario { get; set; }

        public int OrdenIdOrden { get; set; }

        public int ProductoIdProducto { get; set; }
    }
}