using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Registro
{
    public class RegistroModels
    {
        [Required(ErrorMessage = "Es necesario introducir un usuario.")]
        public string User { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una contraseña.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 5 y 20 carácteres.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Es necesario introducir un nombre.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Es necesario introducir un primer apellido.")]
        public string Apellido1 { get; set; }


        [Required(ErrorMessage = "Es necesario introducir un segundo apellido.")]
        public string Apellido2 { get; set; }


        [Required(ErrorMessage = "Es necesario introducir un tipo de usuario.")]
        public int TipoUsuario { get; set; }
    }
}