using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Clave { get; set; }
    }
}