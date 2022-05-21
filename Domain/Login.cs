using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Domain
{
    public class Login
    {
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria.")]
        public string Password { get; set; }
    }
}
