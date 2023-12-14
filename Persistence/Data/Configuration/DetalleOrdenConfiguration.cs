using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<Detalleorden>
    {
        public void Configure(EntityTypeBuilder<Detalleorden> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detalleorden");

            builder.HasIndex(e => e.OrdenIdOrden, "fk_DetalleOrden_Orden1_idx");

            builder.HasIndex(e => e.ProductoIdProducto, "fk_DetalleOrden_Producto1_idx");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("idDetalleOrden");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.OrdenIdOrden).HasColumnName("Orden_idOrden");
            builder.Property(e => e.ProductoIdProducto).HasColumnName("Producto_idProducto");

            builder.HasOne(d => d.OrdenIdOrdenNavigation).WithMany(p => p.Detalleordens)
                .HasForeignKey(d => d.OrdenIdOrden)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DetalleOrden_Orden1");

            builder.HasOne(d => d.ProductoIdProductoNavigation).WithMany(p => p.Detalleordens)
                .HasForeignKey(d => d.ProductoIdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DetalleOrden_Producto1");
        }
    }
}