using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Migrations
{
    /// <inheritdoc />
    public partial class Fin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalFacturado",
                table: "Mesas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Usos",
                table: "Mesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Encuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encuestas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    Importe = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_MesaId",
                table: "Encuestas",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_MesaId",
                table: "Facturas",
                column: "MesaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encuestas");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropColumn(
                name: "TotalFacturado",
                table: "Mesas");

            migrationBuilder.DropColumn(
                name: "Usos",
                table: "Mesas");
        }
    }
}
