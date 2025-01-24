using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Servicios.Implementacion;

public class VentaServicio: IVentaServicio
{
    private readonly HttpClient _UsuarioHttp;

    public VentaServicio(HttpClient http)
    {
        _UsuarioHttp = http;
    }

    public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo)
    {
        var response = await _UsuarioHttp.PostAsJsonAsync("Venta/Registrar", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();

        return result;
    }
}
