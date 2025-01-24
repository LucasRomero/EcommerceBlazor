using Ecommerce.Modelo;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorio.Implementacion;
public sealed class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
{
    private readonly DbecommerceContext _dbContext;
    public VentaRepositorio(DbecommerceContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Venta> Registrar(Venta venta)
    {
        Venta ventaGenerada = new Venta();

        using(var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {

                foreach (DetalleVenta dv in venta.DetalleVenta)
                {
                    Producto producto = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                    producto.Cantidad = producto.Cantidad - dv.Cantidad;
                    _dbContext.Productos.Update(producto);
                }
                await _dbContext.SaveChangesAsync();

                await _dbContext.Venta.AddAsync(venta);
                await _dbContext.SaveChangesAsync();

                ventaGenerada = venta;
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        return ventaGenerada;

    }
}
