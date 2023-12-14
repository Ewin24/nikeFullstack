using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace API.Dtos
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? Precio { get; set; }

        public int CategoriaIdCategoria { get; set; }

        public virtual Categoria CategoriaIdCategoriaNavigation { get; set; } = null!;

        public virtual ICollection<Detallecarrito> Detallecarritos { get; set; } = new List<Detallecarrito>();

        public virtual ICollection<Detalleorden> Detalleordens { get; set; } = new List<Detalleorden>();

        public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
    }
}