using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace API.Dtos
{
    public class OrdenDTO
    {
        public int Id { get; set; }

        public DateOnly? FechaOrden { get; set; }

        public double? Total { get; set; }

        public int UsuarioIdusuario { get; set; }

        public virtual ICollection<Detalleorden> Detalleordens { get; set; } = new List<Detalleorden>();

        public virtual Usuario UsuarioIdusuarioNavigation { get; set; } = null!;
    }
}