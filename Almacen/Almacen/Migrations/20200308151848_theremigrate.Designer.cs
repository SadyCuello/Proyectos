﻿// <auto-generated />
using System;
using Almacen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Almacen.Migrations
{
    [DbContext(typeof(AlmacenContext))]
    [Migration("20200308151848_theremigrate")]
    partial class theremigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clientes", b =>
                {
                    b.Property<int>("CLientesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CLientesID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Empleados", b =>
                {
                    b.Property<int>("EmpleadosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sueldo")
                        .HasColumnType("int");

                    b.HasKey("EmpleadosID");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Productos", b =>
                {
                    b.Property<int>("ProductosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisOrigen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("ProductosID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Ventas", b =>
                {
                    b.Property<int>("VentasID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientesID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpleadoID")
                        .HasColumnType("int");

                    b.Property<int>("ProductosID")
                        .HasColumnType("int");

                    b.HasKey("VentasID");

                    b.HasIndex("ClientesID");

                    b.HasIndex("EmpleadoID");

                    b.HasIndex("ProductosID");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Ventas", b =>
                {
                    b.HasOne("Clientes", "Clientes")
                        .WithMany("Ventas")
                        .HasForeignKey("ClientesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Empleados", "Empleado")
                        .WithMany("Ventas")
                        .HasForeignKey("EmpleadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Productos", "Productos")
                        .WithMany("Ventas")
                        .HasForeignKey("ProductosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
