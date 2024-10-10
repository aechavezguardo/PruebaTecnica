using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Models
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Persona")]
        public int Identificador { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Número de Identificación")]
        public string NumeroIdentificacion { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tipo de Identificación")]
        public string TipoIdentificacion { get; set; }

        [HiddenInput]
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}