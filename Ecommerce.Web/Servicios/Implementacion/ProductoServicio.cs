﻿using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.Web.Servicios.Implementacion;

public class ProductoServicio: IProductoServicio
{
    private readonly HttpClient _UsuarioHttp;

    public ProductoServicio(HttpClient http)
    {
        _UsuarioHttp = http;
    }

    public async Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
    {
        return await _UsuarioHttp.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Catalogo/{categoria}/{buscar}");
    }

    public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo)
    {
        var response = await _UsuarioHttp.PostAsJsonAsync("Producto/Crear", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();

        return result;
    }

    public async Task<ResponseDTO<bool>> Editar(ProductoDTO modelo)
    {
        var response = await _UsuarioHttp.PutAsJsonAsync("Producto/Editar", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

        return result;
    }

    public async Task<ResponseDTO<bool>> Eliminar(int Id)
    {
        return await _UsuarioHttp.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Eliminar/{Id}");
    }

    public async Task<ResponseDTO<List<ProductoDTO>>> Lista(string buscar)
    {
        return await _UsuarioHttp.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Lista/{buscar}");
    }

    public async Task<ResponseDTO<ProductoDTO>> Obtener(int Id)
    {
        return await _UsuarioHttp.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"Producto/Obtener/{Id}");
    }
}
