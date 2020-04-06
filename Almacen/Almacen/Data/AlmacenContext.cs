using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
    public class AlmacenContext : DbContext
    {
        public AlmacenContext (DbContextOptions<AlmacenContext> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Empleados> Empleados { get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Ventas> Ventas { get; set; }
    }
}
