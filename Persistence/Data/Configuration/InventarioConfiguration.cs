using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("inventario");

            builder.HasIndex(e => e.ProductoIdProducto, "fk_Inventario_Producto1_idx");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("idInventario");
            builder.Property(e => e.Existencias).HasColumnName("existencias");
            builder.Property(e => e.FechaActualizacion).HasColumnName("fechaActualizacion");
            builder.Property(e => e.ProductoIdProducto).HasColumnName("Producto_idProducto");

            builder.HasOne(d => d.ProductoIdProductoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoIdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Inventario_Producto1");

        }
    }
}