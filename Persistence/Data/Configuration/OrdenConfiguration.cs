using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.HasKey(e => e.IdOrden).HasName("PRIMARY");

            builder.ToTable("orden");

            builder.HasIndex(e => e.UsuarioIdusuario, "fk_Orden_usuario1_idx");

            builder.Property(e => e.IdOrden)
                .ValueGeneratedNever()
                .HasColumnName("idOrden");
            builder.Property(e => e.UsuarioIdusuario).HasColumnName("usuario_idusuario");

            builder.HasOne(d => d.UsuarioIdusuarioNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.UsuarioIdusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Orden_usuario1");
        }
    }
}