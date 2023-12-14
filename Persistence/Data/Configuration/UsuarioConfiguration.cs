using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Idusuario).HasName("PRIMARY");

            builder.ToTable("usuario");

            builder.HasIndex(e => e.PersonaIdPersona, "fk_usuario_Persona_idx");

            builder.Property(e => e.Idusuario)
                .ValueGeneratedNever()
                .HasColumnName("idusuario");
            builder.Property(e => e.Celular)
                .HasMaxLength(45)
                .HasColumnName("celular");
            builder.Property(e => e.Contraseña).HasMaxLength(255);
            builder.Property(e => e.Correo)
                .HasMaxLength(45)
                .HasColumnName("correo");
            builder.Property(e => e.PersonaIdPersona).HasColumnName("Persona_idPersona");

            builder.HasOne(d => d.PersonaIdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PersonaIdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario_Persona");
        }
    }
}