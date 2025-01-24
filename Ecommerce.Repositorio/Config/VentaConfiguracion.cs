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
internal class VentaConfiguracion : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> entity)
    {
        entity.HasKey(e => e.IdVenta).HasName("PK__Venta__BC1240BDC7CFF82E");

        entity.Property(e => e.FechaCreacion)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

        entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
            .HasForeignKey(d => d.IdUsuario)
            .HasConstraintName("FK__Venta__IdUsuario__2E1BDC42");
    }
}
