using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Usuario")]
        public int Identificador { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string UsuarioNombre { get; set; }

        [Display(Name = "Contraseña")]
        [Required]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Display(Name = "Nueva Contraseña")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string NuevaContrasena { get; set; }

        [Display(Name = "Fecha de Creación")]
        [HiddenInput]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [HiddenInput]
        public byte[] HashKey { get; set; }

        [HiddenInput]
        public byte[] HashIV { get; set; }
    }
}