using Microsoft.EntityFrameworkCore.Migrations;

namespace RecursosHumanos.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSolicitud",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NDocumento",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerNombre",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombre",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdSolicitud",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NDocumento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrimerNombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                table: "AspNetUsers");
        }
    }
}
