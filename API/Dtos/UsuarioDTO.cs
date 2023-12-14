using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace API.Dtos
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string? Contraseña { get; set; }

        public int PersonaIdPersona { get; set; }

        public string? Correo { get; set; }

        public string? Celular { get; set; }

        public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

        public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

        public virtual Persona PersonaIdPersonaNavigation { get; set; } = null!;
    }
}