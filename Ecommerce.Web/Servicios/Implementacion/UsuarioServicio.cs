using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.Web.Servicios.Implementacion;

public class UsuarioServicio : IUsuarioServicio
{

    private readonly HttpClient _UsuarioHttp;

    public UsuarioServicio(HttpClient http)
    {
        _UsuarioHttp = http;
    }
    public async Task<ResponseDTO<SesionDTO>> Autorizacion(UsuarioDTO modelo)
    {
        var response = await _UsuarioHttp.PostAsJsonAsync("Usuario/Autorizacion", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();

        return result;
    }

    public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
    {
        var response = await _UsuarioHttp.PostAsJsonAsync("Usuario/Crear", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();

        return result;
    }

    public async Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo)
    {
        var response = await _UsuarioHttp.PutAsJsonAsync("Usuario/Autorizacion", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

        return result;
    }

    public async Task<ResponseDTO<bool>> Eliminar(int Id)
    {
        return await _UsuarioHttp.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{Id}");
    }

    public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
    {
        return await _UsuarioHttp.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");
    }

    public async Task<ResponseDTO<UsuarioDTO>> Obtener(int Id)
    {
        return await _UsuarioHttp.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Obtener/{Id}");
    }
}
