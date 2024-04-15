using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiRestPlanilla.Models
{
    public class EmpleadoSalario
    {

        public int salario_id { get; set; }

        [Required]
        public int empleado_id { get; set; }

        [Required]
        public decimal salario_base { get; set; }

        [Required]
        public decimal bonifiacaciones { get; set; }

        [Required]
        public decimal deducciones { get; set; }
    }
}
