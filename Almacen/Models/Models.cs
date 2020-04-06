using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Almacen.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }

    }
}
public abstract class Persona
{

    public string Nombre { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]

    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }
}


public class Cliente : Persona
{
    public int CLienteID { get; set; }
    public string Telefono { get; set; }
    public string Empresa { get; set; }

}


public class Empleado : Persona
{
    public int EmpleadoID { get; set; }
    public int Sueldo { get; set; }
    public string Area { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public string CantidadTrabajo { get; set; }
}

public class Producto
{
    public int ProductoID { get; set; }
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public string PaisOrigen { get; set; }
    public string Marca { get; set; }

}