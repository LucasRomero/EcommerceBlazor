using Ecommerce.DTO;

namespace Ecommerce.Web.Servicios.Contrato;

public interface ICarritoServicio
{

    event Action MostratItems;

    int CantidadProductos();
    Task AgregarCarrito(CarritoDTO modelo);
    Task EliminarCarrito(int idProducto);
    Task<List<CarritoDTO>> DevolverCarrito();
    Task LimpiarCarrito();

}
