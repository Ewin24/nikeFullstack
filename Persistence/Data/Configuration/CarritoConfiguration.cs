using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.HasKey(e => e.IdCarrito).HasName("PRIMARY");

            builder.ToTable("carrito");

            builder.HasIndex(e => e.UsuarioIdusuario, "fk_Carrito_usuario1_idx");

            builder.Property(e => e.IdCarrito)
                .ValueGeneratedNever()
                .HasColumnName("idCarrito");
            builder.Property(e => e.UsuarioIdusuario).HasColumnName("usuario_idusuario");

            builder.HasOne(d => d.UsuarioIdusuarioNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.UsuarioIdusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Carrito_usuario1");
        }
    }
}