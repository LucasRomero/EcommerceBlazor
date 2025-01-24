using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.Web.Servicios.Implementacion;

public class CategoriaServicio : ICategoriaServicio
{
    private readonly HttpClient _UsuarioHttp;

    public CategoriaServicio(HttpClient http)
    {
        _UsuarioHttp = http;
    }


    public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo)
    {
        var response = await _UsuarioHttp.PostAsJsonAsync("Categoria/Crear", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();

        return result;
    }

    public async Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo)
    {
        var response = await _UsuarioHttp.PutAsJsonAsync("Categoria/Editar", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

        return result;
    }

    public async Task<ResponseDTO<bool>> Eliminar(int Id)
    {
        return await _UsuarioHttp.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{Id}");
    }

    public async Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar)
    {
        return await _UsuarioHttp.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Categoria/Lista/{buscar}");
    }

    public async Task<ResponseDTO<CategoriaDTO>> Obtener(int Id)
    {
        return await _UsuarioHttp.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Categoria/Obtener/{Id}");
    }
}
