using Microsoft.EntityFrameworkCore;
using ApiRestPlanilla.Models;

namespace ApiRestPlanilla.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<empleado> empleados_personal { get; set; }
        public DbSet<EmpleadoIdentificacion> empleados_identificacion { get; set; }
        public DbSet<EmpleadoSalario> empleados_salarios { get; set; }


        //relacion entre tablas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<empleado>()
                .HasKey(e => e.id);

            modelBuilder.Entity<EmpleadoIdentificacion>()
                .HasKey(e => e.id_empleado);

            modelBuilder.Entity<EmpleadoSalario>()
                .HasKey(e => e.empleado_id);
        }


    }
}
