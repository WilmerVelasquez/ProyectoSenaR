using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecursosHumanos.Data.Migrations
{
    public partial class ConModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreHorario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorario);
                });

            migrationBuilder.CreateTable(
                name: "Suministros",
                columns: table => new
                {
                    IdSuministro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSuministro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suministros", x => x.IdSuministro);
                });

            migrationBuilder.CreateTable(
                name: "RegistroIngresos",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdHorario = table.Column<int>(type: "int", nullable: false),
                    IdHorarioNavigationIdHorario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroIngresos", x => x.IdRegistro);
                    table.ForeignKey(
                        name: "FK_RegistroIngresos_Horarios_IdHorarioNavigationIdHorario",
                        column: x => x.IdHorarioNavigationIdHorario,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: true),
                    Medidas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSuministro = table.Column<int>(type: "int", nullable: true),
                    IdSuministroNavigationIdSuministro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Suministros_IdSuministroNavigationIdSuministro",
                        column: x => x.IdSuministroNavigationIdSuministro,
                        principalTable: "Suministros",
                        principalColumn: "IdSuministro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicituds",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSolicitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSuministro = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdEstadoNavigationIdEstado = table.Column<int>(type: "int", nullable: true),
                    IdSuministroNavigationIdSuministro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicituds", x => x.IdSolicitud);
                    table.ForeignKey(
                        name: "FK_Solicituds_Estados_IdEstadoNavigationIdEstado",
                        column: x => x.IdEstadoNavigationIdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicituds_Suministros_IdSuministroNavigationIdSuministro",
                        column: x => x.IdSuministroNavigationIdSuministro,
                        principalTable: "Suministros",
                        principalColumn: "IdSuministro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdSuministroNavigationIdSuministro",
                table: "Productos",
                column: "IdSuministroNavigationIdSuministro");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroIngresos_IdHorarioNavigationIdHorario",
                table: "RegistroIngresos",
                column: "IdHorarioNavigationIdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_Solicituds_IdEstadoNavigationIdEstado",
                table: "Solicituds",
                column: "IdEstadoNavigationIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Solicituds_IdSuministroNavigationIdSuministro",
                table: "Solicituds",
                column: "IdSuministroNavigationIdSuministro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "RegistroIngresos");

            migrationBuilder.DropTable(
                name: "Solicituds");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Suministros");
        }
    }
}
