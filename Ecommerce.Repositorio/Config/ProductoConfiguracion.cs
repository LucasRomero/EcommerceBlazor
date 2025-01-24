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
internal class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> entity)
    {
        entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210AB644423");

        entity.ToTable("Producto");

        entity.Property(e => e.Descripcion)
            .HasMaxLength(1000)
            .IsUnicode(false);
        entity.Property(e => e.FechaCreacion)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        entity.Property(e => e.Imagen).IsUnicode(false);
        entity.Property(e => e.Nombre)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        entity.Property(e => e.PrecioOferta).HasColumnType("decimal(10, 2)");

        entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
            .HasForeignKey(d => d.IdCategoria)
            .HasConstraintName("FK__Producto__IdCate__276EDEB3");
    }
}
