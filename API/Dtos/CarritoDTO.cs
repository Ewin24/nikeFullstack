using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace API.Dtos
{
    public class CarritoDTO
    {
        public int Id { get; set; }

        public DateOnly? FechaCreacion { get; set; }

        public int UsuarioIdusuario { get; set; }

    }
}