using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.IdProducto).HasName("PRIMARY");

            builder.ToTable("producto");

            builder.HasIndex(e => e.CategoriaIdCategoria, "fk_Producto_Categoria1_idx");

            builder.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("idProducto");
            builder.Property(e => e.CategoriaIdCategoria).HasColumnName("Categoria_idCategoria");
            builder.Property(e => e.Descripcion).HasMaxLength(45);
            builder.Property(e => e.Nombre).HasMaxLength(45);
            builder.Property(e => e.Precio).HasMaxLength(45);

            builder.HasOne(d => d.CategoriaIdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaIdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Producto_Categoria1builder");
        }
    }
}