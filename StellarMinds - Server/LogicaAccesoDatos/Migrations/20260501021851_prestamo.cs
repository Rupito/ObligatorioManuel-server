using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class prestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdSocio = table.Column<int>(type: "int", nullable: true),
                    IdMontura = table.Column<int>(type: "int", nullable: true),
                    IdTelescopio = table.Column<int>(type: "int", nullable: true),
                    IdEquipoVisual = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_IdEquipoVisual",
                        column: x => x.IdEquipoVisual,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo");
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_IdMontura",
                        column: x => x.IdMontura,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo");
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_IdTelescopio",
                        column: x => x.IdTelescopio,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo");
                    table.ForeignKey(
                        name: "FK_Prestamos_Socios_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socios",
                        principalColumn: "IdSocio");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdEquipoVisual",
                table: "Prestamos",
                column: "IdEquipoVisual");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdMontura",
                table: "Prestamos",
                column: "IdMontura");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdSocio",
                table: "Prestamos",
                column: "IdSocio");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdTelescopio",
                table: "Prestamos",
                column: "IdTelescopio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
