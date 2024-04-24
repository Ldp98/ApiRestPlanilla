using System.ComponentModel.DataAnnotations;

namespace ApiRestPlanilla.Models
{
    public class EmpleadoDto
    {
        public int id { get; set; }

        [Required]
        public string nombres { get; set; }

        [Required]
        public string apellidos { get; set; }

        [Required]
        public string genero { get; set; }

        /*[Required]
        public DateTime fecha_nacimiento { get; set; }*/
        [Required]
        public string estado_civil { get; set; }

        [Required]
        public int edad { get; set; }

        /* [Required]
         public DateTime fecha_creacion { get; set; }

         [Required]
         public DateTime fecha_modificacion { get; set; }*/

        //public string usuario_creacion { get; set; }

        //public string usuario_modificacion { get; set; }

        [Required]
        public string activo { get; set; }

        [Required]
        public string dpi { get; set; }

        [Required]
        public string nit { get; set; }

        [Required]
        public string afiliacion_igss { get; set; }

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

        [Required]
        public decimal salario_base { get; set; }

        [Required]
        public decimal bonificaciones { get; set; }

        [Required]
        public decimal deducciones { get; set; }


        public string plaza { get; set; }

    }
}
