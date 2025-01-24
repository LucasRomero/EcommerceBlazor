using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO;
public class TarjetaDTO
{
    [Required(ErrorMessage = "El campo Titular es requerido")]
    public string? Titular { get; set; }
    [Required(ErrorMessage = "El campo Numero es requerido")]
    public string? Numero { get; set; }
    [Required(ErrorMessage = "El campo Vigencia es requerido")]
    public string? Vigencia { get; set; }
    [Required(ErrorMessage = "El campo CVV es requerido")]
    public string? CVV { get; set; }
}
