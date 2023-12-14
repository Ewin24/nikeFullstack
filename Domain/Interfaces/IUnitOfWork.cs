
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    DbSet<T> Set<T>() where T : class;
    ICarrito Carritos { get; }
    ICategoria Categorias { get; }
    IDetalleCarrito DetalleCarritos { get; }
    IDetalleOrden DetalleOrdenes { get; }
    IInventario Inventarios { get; }
    IOrden Ordenes { get; }
    IPersona Personas { get; }
    IProducto Productos { get; }
    IUsuario Usuarios { get; }
    Task<int> SaveAsync();
}