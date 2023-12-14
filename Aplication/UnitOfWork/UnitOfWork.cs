using Aplication.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Entities;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DotnetContext _context;
    public UnitOfWork(DotnetContext context)
    {
        _context = context;
    }

    public ICarrito _carrito;
    public ICarrito Carrito
    {
        get
        {
            if (_carrito == null)
            {
                _carrito = new CarritoRepository(_context);
            }
            return _carrito;
        }
    }

    public ICategoria _categoria;
    public ICategoria Categoria
    {
        get
        {
            if (_categoria == null)
            {
                _categoria = new CategoriaRepository(_context);
            }
            return _categoria;
        }
    }

    public IDetalleCarrito _detalleCarrito;
    public IDetalleCarrito DetalleCarrito
    {
        get
        {
            if (_detalleCarrito == null)
            {
                _detalleCarrito = new DetalleCarritoRepository(_context);
            }
            return _detalleCarrito;
        }
    }

    public IDetalleOrden _detalleOrden;
    public IDetalleOrden DetalleOrden
    {
        get
        {
            if (_detalleOrden == null)
            {
                _detalleOrden = new DetalleOrdenRepository(_context);
            }
            return _detalleOrden;
        }
    }

    public IInventario _inventario;
    public IInventario Inventario
    {
        get
        {
            if (_inventario == null)
            {
                _inventario = new InventarioRepository(_context);
            }
            return _inventario;
        }
    }

    public IOrden _orden;
    public IOrden Orden
    {
        get
        {
            if (_orden == null)
            {
                _orden = new OrdenRepository(_context);
            }
            return _orden;
        }
    }

    public IPersona _persona;
    public IPersona Persona
    {
        get
        {
            if (_persona == null)
            {
                _persona = new PersonaRepository(_context);
            }
            return _persona;
        }
    }

    public IProducto _producto;
    public IProducto Producto
    {
        get
        {
            if (_producto == null)
            {
                _producto = new ProductoRepository(_context);
            }
            return _producto;
        }
    }

    public IUsuario _usuario;
    public IUsuario Usuario
    {
        get
        {
            if (_usuario == null)
            {
                _usuario = new UsuarioRepository(_context);
            }
            return _usuario;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public DbSet<T> Set<T>() where T : class
    {
        throw new NotImplementedException();
    }
}