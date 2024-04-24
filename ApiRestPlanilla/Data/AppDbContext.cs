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
                .HasOne(ep => ep.EmpleadoIdentificacion)
                .WithOne(ei => ei.empleado)
                .HasForeignKey<EmpleadoIdentificacion>(ei => ei.id_empleado);

            modelBuilder.Entity<empleado>()
                .HasOne(ep => ep.EmpleadoSalario)
                .WithOne(es => es.empleado)
                .HasForeignKey<EmpleadoSalario>(es => es.empleado_id);
        }


    }
}
