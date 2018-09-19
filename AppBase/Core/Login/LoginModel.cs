using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Login
{
    public class LoginModels
    {
        [Required(ErrorMessage = "Es necesario introducir un usuario.")]
        public string User { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una contraseña.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 5 y 20 carácteres.")]
        public string Password { get; set; }
    }
}
