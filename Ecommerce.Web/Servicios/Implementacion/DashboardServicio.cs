using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.Web.Servicios.Implementacion;

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
