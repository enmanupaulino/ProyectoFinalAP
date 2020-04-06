using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalAp2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Deuda = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    IdEntrada = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas", x => x.IdEntrada);
                });

            migrationBuilder.CreateTable(
                name: "facturacion",
                columns: table => new
                {
                    IdFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    IdProducto = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturacion", x => x.IdFactura);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 25, nullable: false),
                    IdProveedor = table.Column<int>(nullable: false),
                    IdCategoria = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    Ganancia = table.Column<decimal>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Direccion = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "trabajos",
                columns: table => new
                {
                    IdTrabajo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    CantidadHojas = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajos", x => x.IdTrabajo);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Usuario = table.Column<string>(maxLength: 20, nullable: false),
                    NivelUsuario = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "EntradasDetalles",
                columns: table => new
                {
                    IdEntradaDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEntrada = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasDetalles", x => x.IdEntradaDetalle);
                    table.ForeignKey(
                        name: "FK_EntradasDetalles_entradas_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "entradas",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturacionDetalle",
                columns: table => new
                {
                    IdFacturaDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactura = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Importe = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturacionDetalle", x => x.IdFacturaDetalle);
                    table.ForeignKey(
                        name: "FK_FacturacionDetalle_facturacion_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "facturacion",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrabajoDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTrabajo = table.Column<int>(nullable: false),
                    CantidadHojas = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrabajoDetalle_trabajos_IdTrabajo",
                        column: x => x.IdTrabajo,
                        principalTable: "trabajos",
                        principalColumn: "IdTrabajo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasDetalles_IdEntrada",
                table: "EntradasDetalles",
                column: "IdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_FacturacionDetalle_IdFactura",
                table: "FacturacionDetalle",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajoDetalle_IdTrabajo",
                table: "TrabajoDetalle",
                column: "IdTrabajo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "EntradasDetalles");

            migrationBuilder.DropTable(
                name: "FacturacionDetalle");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "TrabajoDetalle");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "entradas");

            migrationBuilder.DropTable(
                name: "facturacion");

            migrationBuilder.DropTable(
                name: "trabajos");
        }
    }
}
