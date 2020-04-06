using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Almacen.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

    }
}
public abstract class Persona
{
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]

    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }
}


public class Clientes : Persona
{
    public int CLientesID { get; set; }
    public string Telefono { get; set; }
    public string Empresa { get; set; }
    public virtual ICollection<Ventas> Ventas { get; set; }
}


public class Empleados : Persona
{
    public int EmpleadosID { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public int Sueldo { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Area { get; set; }
    public virtual ICollection<Ventas> Ventas { get; set; }
}

public class Productos
{
    public int ProductosID { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public string PaisOrigen { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Marca { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public int Precio { get; set; }
    public virtual ICollection<Ventas> Ventas { get; set; }

}
public class Ventas
{
    public int VentasID { get; set; }
    [Required(ErrorMessage = "Empleado Requerido ")]
    public int EmpleadoID { get; set; }
    public virtual Empleados Empleado { get; set; }
    [Required(ErrorMessage = "Cliente Requerido ")]
    public int ClientesID { get; set; }
    public virtual Clientes Clientes { get; set; }
    [Required(ErrorMessage = "Productos Requerido ")]
    public int ProductosID { get; set; }
    public virtual Productos Productos { get; set; }
    public DateTime DateTime { get; set; }
}