﻿using Ecommerce.DTO;

namespace Ecommerce.Web.Servicios.Contrato;

public interface IUsuarioServicio
{
    Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar);
    Task<ResponseDTO<UsuarioDTO>> Obtener(int Id);
    Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
    Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);
    Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo);
    Task<ResponseDTO<bool>> Eliminar(int Id);

}
