using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ApiRestPlanilla.Models
{
    public class empleado
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

    }
}
