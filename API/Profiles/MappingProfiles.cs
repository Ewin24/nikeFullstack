using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Persistence.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Carrito, CarritoDTO>().ReverseMap();
            CreateMap<Detallecarrito, DetalleCarritoDTO>().ReverseMap();
            CreateMap<Detalleorden, DetalleOrdenDTO>().ReverseMap();
            CreateMap<Inventario, InventarioDTO>().ReverseMap();
            CreateMap<Orden, OrdenDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Persona, PersonaDTO>().ReverseMap();
        }
    }
}