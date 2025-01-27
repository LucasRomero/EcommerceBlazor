using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Utilidades;
public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Usuario, UsuarioDTO>();
        CreateMap<Usuario, SesionDTO>();
        CreateMap<UsuarioDTO, Usuario>();


        CreateMap<Producto, ProductoDTO>();
        CreateMap<ProductoDTO, Producto>();

        CreateMap<Producto, ProductoDTO>();
        CreateMap<ProductoDTO, Producto>().ForMember(destino => 
            destino.IdCategoriaNavigation, opt => opt.Ignore()
        );

        CreateMap<Categoria, CategoriaDTO>();
        CreateMap<CategoriaDTO, Categoria>();

        CreateMap<DetalleVenta, DetalleVentaDTO>();
        CreateMap<DetalleVentaDTO, DetalleVenta>();

        CreateMap<Venta, VentaDTO>();
        CreateMap<VentaDTO, Venta>();

    }
}
