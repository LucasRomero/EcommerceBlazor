using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO;
public class ProductoDTO
{
    public int IdProducto { get; set; }

    [Required(ErrorMessage = "El campo Nombre es requerido")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo Descripcion es requerido")]
    public string? Descripcion { get; set; }
    public int? IdCategoria { get; set; }

    [Required(ErrorMessage = "El campo Precio es requerido")]
    public decimal? Precio { get; set; }

    [Required(ErrorMessage = "El campo Precio Oferta es requerido")]
    public decimal? PrecioOferta { get; set; }

    [Required(ErrorMessage = "El campo Cantidad es requerido")]
    public int? Cantidad { get; set; }

    [Required(ErrorMessage = "El campo Imagen es requerido")]
    public string? Imagen { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public CategoriaDTO IdCategoriaNavigation { get; set; }
}
