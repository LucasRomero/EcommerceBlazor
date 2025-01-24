using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;

namespace Ecommerce.Web.Servicios.Implementacion;

public class CarritoServicio: ICarritoServicio
{

    private ILocalStorageService _localStorage;
    private ISyncLocalStorageService _syncLocalStorage;
    private IToastService _toastService;

    public CarritoServicio(
    ILocalStorageService localStorage,
    ISyncLocalStorageService syncLocalStorage,
    IToastService toastService)
    {
        _localStorage = localStorage;
        _syncLocalStorage = syncLocalStorage;
        _toastService = toastService;
    }

    public event Action MostratItems;

    public async Task AgregarCarrito(CarritoDTO modelo)
    {
        try
        {
            var carrito = await _localStorage.GetItemAsync<List<CarritoDTO>>("carrito");
            if (carrito == null)
                carrito = new List<CarritoDTO>();

            var encontrado = carrito.FirstOrDefault(x => x.Producto.IdProducto == modelo.Producto.IdProducto);

            if(encontrado != null)
                carrito.Remove(encontrado);

            carrito.Add(modelo);
            await _localStorage.SetItemAsync("carrito", carrito);

            if(encontrado != null)
                _toastService.ShowSuccess("Producto actualizado en el carrito");
            else
                _toastService.ShowSuccess("Producto agregado al carrito");

            MostratItems.Invoke();

        }
        catch (Exception)
        {
            _toastService.ShowError("No se pudo agregar al carrito");
            throw;
        }
    }

    public int CantidadProductos()
    {
        var carrito = _syncLocalStorage.GetItem<List<CarritoDTO>>("carrito");
        return carrito == null ? 0 : carrito.Count;
    }

    public async Task<List<CarritoDTO>> DevolverCarrito()
    {
        var carrito = await _localStorage.GetItemAsync<List<CarritoDTO>>("carrito");
        if(carrito is null)
            carrito = new List<CarritoDTO>();

        return carrito;
    }

    public async Task EliminarCarrito(int idProducto)
    {
        try
        {
            var carrito = await _localStorage.GetItemAsync<List<CarritoDTO>>("carrito");
            if(carrito is not null)
            {
                var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProducto);
                if(elemento is not null)
                {
                    carrito.Remove(elemento);
                    await _localStorage.SetItemAsync("carrito", carrito);
                    MostratItems.Invoke();
                }
            }
        }
        catch (Exception)
        {

            _toastService.ShowError("No se pudo agregar al carrito");
            throw;
        }
    }

    public async Task LimpiarCarrito()
    {
        await _localStorage.RemoveItemAsync("carrito");
    }
}
