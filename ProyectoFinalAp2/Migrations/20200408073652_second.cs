using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalAp2.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "facturacion");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "facturacion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "facturacion");

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "facturacion",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
