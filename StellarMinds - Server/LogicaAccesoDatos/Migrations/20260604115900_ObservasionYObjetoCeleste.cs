using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ObservasionYObjetoCeleste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjetosCelestes",
                columns: table => new
                {
                    IdObjetoCeleste = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoObjeto = table.Column<int>(type: "int", nullable: false),
                    MagnitudAparente_MagnitudAparente = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosCelestes", x => x.IdObjetoCeleste);
                });

            migrationBuilder.CreateTable(
                name: "Observaciones",
                columns: table => new
                {
                    IdObservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaObservacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Indicador = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    IdPrestamo = table.Column<int>(type: "int", nullable: false),
                    IdObjetoCeleste = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observaciones", x => x.IdObservacion);
                    table.ForeignKey(
                        name: "FK_Observaciones_ObjetosCelestes_IdObjetoCeleste",
                        column: x => x.IdObjetoCeleste,
                        principalTable: "ObjetosCelestes",
                        principalColumn: "IdObjetoCeleste",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observaciones_Prestamos_IdPrestamo",
                        column: x => x.IdPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observaciones_Socios_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socios",
                        principalColumn: "IdSocio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_IdObjetoCeleste",
                table: "Observaciones",
                column: "IdObjetoCeleste");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_IdPrestamo",
                table: "Observaciones",
                column: "IdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_IdSocio",
                table: "Observaciones",
                column: "IdSocio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observaciones");

            migrationBuilder.DropTable(
                name: "ObjetosCelestes");
        }
    }
}
