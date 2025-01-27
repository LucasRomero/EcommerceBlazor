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
internal class DetalleVentaConfiguracion : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> entity)
    {
        entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DetalleV__AAA5CEC210420A7F");

        entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

        entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
            .HasForeignKey(d => d.IdProducto)
            .HasConstraintName("FK__DetalleVe__IdPro__32E0915F");

        entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
            .HasForeignKey(d => d.IdVenta)
            .HasConstraintName("FK__DetalleVe__IdVen__31EC6D26");
    }
}
