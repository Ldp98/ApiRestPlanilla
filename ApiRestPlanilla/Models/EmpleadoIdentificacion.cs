using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiRestPlanilla.Models
{
    public class EmpleadoIdentificacion
    {

        public int id_empleado { get; set; }

        [Required]
        public string dpi { get; set; }

        [Required]
        public string nit { get; set; }

        [Required]
        public string afilicacion_igss { get; set; }

        [Required]
        public string afiliacion_irtra { get; set; }

        [Required]
        public string pasaporte { get; set; }

        [Required]
        public string seguro_medico { get; set; }

        [Required]
        public string direccion { get; set; }

        [Required]
        public string ciudad { get; set; }

        [Required]
        public string pais { get; set; }

        [Required]
        public string codigo_postal { get; set; }

        [Required]
        public string telefono { get; set; }

        [Required]
        public string email { get; set; }

    }
}
