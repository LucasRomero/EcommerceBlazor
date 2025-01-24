using Ecommerce.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorio.Config;
internal class CategoriaConfiguracion: IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> entity)
    {
        entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A1069639474");

        entity.Property(e => e.FechaCreacion)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        entity.Property(e => e.Nombre)
            .HasMaxLength(59)
            .IsUnicode(false);
    }
}
