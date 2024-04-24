using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestPlanilla.Models
{
    public class EmpleadoSalario
    {
        
        public int salario_id { get; set; }

        [Required]
        [Key, ForeignKey("empleado")]
        public int empleado_id { get; set; }

        [Required]
        public decimal salario_base { get; set; }

        [Required]
        public decimal bonificaciones { get; set; }

        [Required]
        public decimal deducciones { get; set; }

  
        public string plaza { get; set; }

        public virtual empleado empleado { get; set; }

    }
}
