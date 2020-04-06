using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almacen.Migrations
{
    public partial class secondmigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CLientesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Empresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CLientesID);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Sueldo = table.Column<int>(nullable: false),
                    Area = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadosID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    PaisOrigen = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Precio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductosID);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoID = table.Column<int>(nullable: false),
                    ClientesID = table.Column<int>(nullable: false),
                    ProductosID = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentasID);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClientesID",
                        column: x => x.ClientesID,
                        principalTable: "Clientes",
                        principalColumn: "CLientesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Productos_ProductosID",
                        column: x => x.ProductosID,
                        principalTable: "Productos",
                        principalColumn: "ProductosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClientesID",
                table: "Ventas",
                column: "ClientesID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpleadoID",
                table: "Ventas",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ProductosID",
                table: "Ventas",
                column: "ProductosID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
