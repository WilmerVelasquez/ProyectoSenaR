using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecursosHumanos.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Estado> Estados {get; set;}
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<RegistroIngreso> RegistroIngresos { get; set; }
        public virtual DbSet<Solicitud> Solicituds { get; set; }
        public virtual DbSet<Suministro> Suministros { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        


    }
}
