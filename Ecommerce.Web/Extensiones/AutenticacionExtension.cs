using Blazored.LocalStorage;
using Ecommerce.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;


namespace Ecommerce.Web.Extensiones;

public class AutenticacionExtension: AuthenticationStateProvider
{

    private readonly ILocalStorageService _localStorageService;
    private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());
    public AutenticacionExtension(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task ActulizarEstadoAutenticacion(SesionDTO? sesionUsuario)
    {
        ClaimsPrincipal claimsPrincipal;

        if(sesionUsuario is not null)
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.NombreCompleto.ToString()),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol),
                }, "JwtAuth"));

            await _localStorageService.SetItemAsync("sesionUsuario", sesionUsuario);
        }

        else
        {
            claimsPrincipal = _sinInformacion;
            await _localStorageService.RemoveItemAsync("sesionUsuario");
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var sesionUsuario = await _localStorageService.GetItemAsync<SesionDTO>("sesionUsuario");

        if(sesionUsuario is null)
            return await Task.FromResult(new AuthenticationState(_sinInformacion));

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, sesionUsuario.NombreCompleto.ToString()),
                new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                new Claim(ClaimTypes.Role, sesionUsuario.Rol),
            }, "JwtAuth"));

        return await Task.FromResult(new AuthenticationState(claimsPrincipal));

    }
}
