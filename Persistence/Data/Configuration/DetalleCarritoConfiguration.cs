using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class DetalleCarritoConfiguration : IEntityTypeConfiguration<Detallecarrito>
    {
        public void Configure(EntityTypeBuilder<Detallecarrito> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detallecarrito");

            builder.HasIndex(e => e.CarritoIdCarrito, "fk_DetalleCarrito_Carrito1_idx");

            builder.HasIndex(e => e.ProductoIdProducto, "fk_DetalleCarrito_Producto1_idx");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("idDetalleCarrito");
            builder.Property(e => e.CarritoIdCarrito).HasColumnName("Carrito_idCarrito");
            builder.Property(e => e.ProductoIdProducto).HasColumnName("Producto_idProducto");

            builder.HasOne(d => d.CarritoIdCarritoNavigation).WithMany(p => p.Detallecarritos)
                .HasForeignKey(d => d.CarritoIdCarrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DetalleCarrito_Carrito1");

            builder.HasOne(d => d.ProductoIdProductoNavigation).WithMany(p => p.Detallecarritos)
                .HasForeignKey(d => d.ProductoIdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DetalleCarrito_Producto1");
        }
    }
}