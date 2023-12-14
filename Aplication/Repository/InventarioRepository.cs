using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Interfaces;
using Persistence.Data;
using Persistence.Entities;

namespace Aplication.Repository
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        private readonly DotnetContext _context;

        public InventarioRepository(DotnetContext context) : base(context)
        {
            _context = context;
        }
    }
}