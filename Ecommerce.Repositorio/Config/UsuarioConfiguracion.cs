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
internal class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entity)
    {
        entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97A376D9BA");

        entity.ToTable("Usuario");

        entity.Property(e => e.Clave)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Correo)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.FechaCreacion)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        entity.Property(e => e.NombreCompleto)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Rol)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
