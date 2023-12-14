
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    DbSet<T> Set<T>() where T : class;
    ICarrito Carrito { get; }
    ICategoria Categoria { get; }
    IDetalleCarrito DetalleCarrito { get; }
    IDetalleOrden DetalleOrden { get; }
    IInventario Inventario { get; }
    IOrden Orden { get; }
    IPersona Persona { get; }
    IProducto Producto { get; }
    IUsuario Usuario { get; }
    Task<int> SaveAsync();
}