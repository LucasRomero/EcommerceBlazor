using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Servicios.Implementacion;

public class DashboardServicio: IDashboardServicio
{
    private readonly HttpClient _UsuarioHttp;

    public DashboardServicio(HttpClient http)
    {
        _UsuarioHttp = http;
    }

    public async Task<ResponseDTO<DashboardDTO>> Resumen()
    {
        return await _UsuarioHttp.GetFromJsonAsync<ResponseDTO<DashboardDTO>>($"Dashboard/Resumen");
    }
}
