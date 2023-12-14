using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Data.Configuration
{
    public class CategoriaConfiguration: IEntityTypeConfiguration<Categoria>
    {
        

        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("categoria");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("idCategoria");
            builder.Property(e => e.Nombre).HasMaxLength(45);
        }
    }
}