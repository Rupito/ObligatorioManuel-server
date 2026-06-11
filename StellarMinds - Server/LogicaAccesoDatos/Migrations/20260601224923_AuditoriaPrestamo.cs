using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AuditoriaPrestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAltaPrestamo",
                table: "Prestamos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDevolucionPrestamo",
                table: "Prestamos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSocioAltaPrestamo",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSocioDevolucionPrestamo",
                table: "Prestamos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAltaPrestamo",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "FechaDevolucionPrestamo",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "IdSocioAltaPrestamo",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "IdSocioDevolucionPrestamo",
                table: "Prestamos");
        }
    }
}
