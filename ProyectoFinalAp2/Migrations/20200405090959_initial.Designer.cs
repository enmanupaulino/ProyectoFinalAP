﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinalAp2.Data;

namespace ProyectoFinalAp2.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200405090959_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("ProyectoFinalAp2.Models.Categorias", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("IdCategoria");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Clientes", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Deuda")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Entradas", b =>
                {
                    b.Property<int>("IdEntrada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("IdEntrada");

                    b.ToTable("entradas");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.EntradasDetalles", b =>
                {
                    b.Property<int>("IdEntradaDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdEntrada")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdEntradaDetalle");

                    b.HasIndex("IdEntrada");

                    b.ToTable("EntradasDetalles");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Facturacion", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario")
                        .HasColumnType("TEXT");

                    b.HasKey("IdFactura");

                    b.ToTable("facturacion");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.FacturacionDetalle", b =>
                {
                    b.Property<int>("IdFacturaDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdFactura")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Importe")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("IdFacturaDetalle");

                    b.HasIndex("IdFactura");

                    b.ToTable("FacturacionDetalle");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Productos", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Ganancia")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("IdProducto");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Proveedores", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("IdProveedor");

                    b.ToTable("proveedores");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.TrabajoDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CantidadHojas")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdTrabajo")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdTrabajo");

                    b.ToTable("TrabajoDetalle");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Trabajos", b =>
                {
                    b.Property<int>("IdTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CantidadHojas")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("IdTrabajo");

                    b.ToTable("trabajos");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("NivelUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.HasKey("IdUsuario");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.EntradasDetalles", b =>
                {
                    b.HasOne("ProyectoFinalAp2.Models.Entradas", null)
                        .WithMany("Detalle")
                        .HasForeignKey("IdEntrada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.FacturacionDetalle", b =>
                {
                    b.HasOne("ProyectoFinalAp2.Models.Facturacion", null)
                        .WithMany("Detalle")
                        .HasForeignKey("IdFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.TrabajoDetalle", b =>
                {
                    b.HasOne("ProyectoFinalAp2.Models.Trabajos", null)
                        .WithMany("Detalles")
                        .HasForeignKey("IdTrabajo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
