using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestPlanilla.Data;
using ApiRestPlanilla.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleado(int id)
        {
            var empleado = await _context.empleados_personal
                .Include(e => e.EmpleadoIdentificacion)
                .Include(e => e.EmpleadoSalario)
                .FirstOrDefaultAsync(e => e.id == id && e.activo == "S");

            if( empleado == null)
            {
                return NotFound();
            }

            var empleadoDTO = new EmpleadoDto
            {
                id = empleado.id,
                nombres = empleado.nombres,
                apellidos = empleado.apellidos,
                edad = empleado.edad,
                genero = empleado.genero,
                estado_civil = empleado.estado_civil,
                activo = empleado.activo,
                dpi = empleado.EmpleadoIdentificacion.dpi,
                nit = empleado.EmpleadoIdentificacion.nit,
                afiliacion_igss = empleado.EmpleadoIdentificacion.afiliacion_igss,
                afiliacion_irtra = empleado.EmpleadoIdentificacion.afiliacion_irtra,
                pasaporte = empleado.EmpleadoIdentificacion.pasaporte,
                seguro_medico = empleado.EmpleadoIdentificacion.seguro_medico,
                direccion = empleado.EmpleadoIdentificacion.direccion,
                ciudad = empleado.EmpleadoIdentificacion.ciudad,
                pais = empleado.EmpleadoIdentificacion.pais,
                codigo_postal = empleado.EmpleadoIdentificacion.codigo_postal,
                telefono = empleado.EmpleadoIdentificacion.telefono,
                email = empleado.EmpleadoIdentificacion.email,
                salario_base = empleado.EmpleadoSalario.salario_base,
                bonificaciones = empleado.EmpleadoSalario.bonificaciones,
                deducciones = empleado.EmpleadoSalario.deducciones,
                plaza = empleado.EmpleadoSalario.plaza
            };

            return empleadoDTO;
        }

        [HttpGet]
        public ActionResult<IEnumerable<empleado>> GetEmpleados()
        {
            //return _context.empleados_personal.ToList();

            var empleadosActivos = _context.empleados_personal.Where(e => e.activo == "S").ToList();
            return empleadosActivos;

        }


        [HttpPost]
        public IActionResult PostEmpleado(EmpleadoDto empleadoDto)
        {
            // Verificar si el empleado ya existe (por ejemplo, por su DPI)
            var empleadoExistente = _context.empleados_identificacion.FirstOrDefault(ei => ei.dpi == empleadoDto.dpi);
            if (empleadoExistente != null)
            {
                return Conflict("Ya existe un empleado con este DPI"); // Devuelve un código 409 si el empleado ya existe
            }

            // Crear un nuevo empleado personal con los datos proporcionados en empleadoDto
            var nuevoEmpleado = new empleado
            {
                nombres = empleadoDto.nombres,
                apellidos = empleadoDto.apellidos,
                edad = empleadoDto.edad,
                genero = empleadoDto.genero,
                estado_civil = empleadoDto.estado_civil,
                activo = "S" // Por defecto, se considera activo al crearlo
            };
            _context.empleados_personal.Add(nuevoEmpleado);
            _context.SaveChanges();

            // Crear una nueva identificación para el empleado
            var nuevaIdentificacion = new EmpleadoIdentificacion
            {
                id_empleado = nuevoEmpleado.id, // Usar el ID del nuevo empleado
                dpi = empleadoDto.dpi,
                nit = empleadoDto.nit,
                afiliacion_igss = empleadoDto.afiliacion_igss,
                afiliacion_irtra = empleadoDto.afiliacion_irtra,
                pasaporte = empleadoDto.pasaporte,
                seguro_medico = empleadoDto.seguro_medico,
                direccion = empleadoDto.direccion,
                ciudad = empleadoDto.ciudad,
                pais = empleadoDto.pais,
                codigo_postal = empleadoDto.codigo_postal,
                telefono = empleadoDto.telefono,
                email = empleadoDto.email
            };
            _context.empleados_identificacion.Add(nuevaIdentificacion);
            _context.SaveChanges();

            // Devolver el nuevo empleado creado con su ID
            return CreatedAtAction(nameof(GetEmpleado), new { id = nuevoEmpleado.id }, empleadoDto);
        }


        [HttpPut("{id}")]
        public IActionResult PutEmpleado(int id, EmpleadoDto empleadoDto)
        {
            var empleado = _context.empleados_personal.FirstOrDefault(ep => ep.id == id && ep.activo == "S");

            if (empleado == null)
            {
                return NotFound(); // Devuelve un código 404 si no se encuentra el empleado
            }

            // Actualizar propiedades del empleado con los valores de empleadoDto
            empleado.nombres = empleadoDto.nombres;
            empleado.apellidos = empleadoDto.apellidos;
            empleado.edad = empleadoDto.edad;
            empleado.genero = empleadoDto.genero;
            empleado.estado_civil = empleadoDto.estado_civil;

            // Actualizar identificación del empleado
            var identificacion = _context.empleados_identificacion.FirstOrDefault(ei => ei.id_empleado == id);
            if (identificacion != null)
            {
           
                identificacion.dpi = empleadoDto.dpi;
                identificacion.nit = empleadoDto.nit;
                identificacion.afiliacion_igss = empleadoDto.afiliacion_igss;
                identificacion.afiliacion_irtra = empleadoDto.afiliacion_irtra;
                identificacion.pasaporte = empleadoDto.pasaporte;
                identificacion.seguro_medico = empleadoDto.seguro_medico;
                identificacion.direccion = empleadoDto.direccion;
                identificacion.ciudad = empleadoDto.ciudad;
                identificacion.pais = empleadoDto.pais;
                identificacion.codigo_postal = empleadoDto.codigo_postal;
                identificacion.telefono = empleadoDto.telefono;
                identificacion.email = empleadoDto.email;
            }

            // Guardar cambios en la base de datos
            _context.SaveChanges();

            return NoContent(); // Devuelve un código 204 para indicar que la actualización fue exitosa
        }


    }
}
