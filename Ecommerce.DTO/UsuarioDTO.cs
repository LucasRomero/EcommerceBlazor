﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO;
public class UsuarioDTO
{
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "El campo Nombre Completo es requerido")]
    public string? NombreCompleto { get; set; }

    [Required(ErrorMessage = "El campo Correo es requerido")]
    public string? Correo { get; set; }

    [Required(ErrorMessage = "El campo Clave es requerido")]
    public string? Clave { get; set; }
    [Required(ErrorMessage = "El campo Confirmar Clave es requerido")]
    public string? ConfirmarClave { get; set; }

    public string? Rol { get; set; }

}
