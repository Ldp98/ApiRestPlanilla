using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestPlanilla.Data;
using ApiRestPlanilla.Models;

namespace ApiRestPlanilla.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpleadosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<empleado>> GetEmpleados()
        {
            //return _context.empleados_personal.ToList();

            var empleadosActivos = _context.empleados_personal.Where(e => e.activo == "S").ToList();
            return empleadosActivos;
            /*var consulta = (from personal in _context.empleados_personal
                            join identificacion in _context.empleados_identificacion
                            on personal.id equals identificacion.id_empleado
                            join salario in _context.empleados_salarios
                            on personal.id equals salario.empleado_id
                            select new
                            {
                                personal.id,
                                personal.nombres,
                                personal.apellidos
                            }).ToList();*/

            /*var consulta = (from personal in _context.empleados_personal
                            join identificacion in _context.empleados_identificacion
                            on personal.id equals identificacion.id_empleado
                            join salario in _context.empleados_salarios
                            on personal.id equals salario.empleado_id
                            select new empleado
                            {
                                id = personal.id,
                                nombres = personal.nombres,
                                apellidos = personal.apellidos
                            }).ToList();

            return consulta;*/

        }

        [HttpGet("{id}")]
        public ActionResult<empleado> GetEmpleado(int id)
        {
            var empleado = _context.empleados_personal.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        [HttpPost]
        public ActionResult<empleado> PostEmpleado(empleado empleado)
        {
            _context.empleados_personal.Add(empleado);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.id }, empleado);
        }

        [HttpPut("{id}")]
        public IActionResult PutEmpleado(int id, empleado empleado)
        {
            if (id != empleado.id)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        /* [HttpDelete("{id}")]
         public IActionResult DeleteEmpleado(int id)
         {
             var empleado = _context.empleados_personal.Find(id);

             if (empleado == null)
             {
                 return NotFound();
             }

             _context.Usuarios.Remove(empleado);
             _context.SaveChanges();

             return NoContent();
         }*/
    }
}
