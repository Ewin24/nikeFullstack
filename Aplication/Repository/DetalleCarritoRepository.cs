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
    public class DetalleCarritoRepository : GenericRepository<Detallecarrito>, IDetalleCarrito
    {
        private readonly DotnetContext _context;

        public DetalleCarritoRepository(DotnetContext context) : base(context)
        {
            _context = context;
        }
    }
}