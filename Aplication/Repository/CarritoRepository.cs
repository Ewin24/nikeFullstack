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
    public class CarritoRepository : GenericRepository<Carrito>, ICarrito
    {
        private readonly DotnetContext _context;

        public CarritoRepository(DotnetContext context) : base(context)
        {
            _context = context;
        }
    }
}