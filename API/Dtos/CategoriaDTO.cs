using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace API.Dtos
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

    }
}