using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("persona");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("idPersona");
            builder.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            builder.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        }
    }
}