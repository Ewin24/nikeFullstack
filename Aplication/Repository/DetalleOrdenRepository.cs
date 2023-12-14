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
    public class DetalleOrdenRepository : GenericRepository<Detalleorden>, IDetalleOrden
    {
        private readonly DotnetContext _context;

        public DetalleOrdenRepository(DotnetContext context) : base(context)
        {
            _context = context;
        }
    }
}