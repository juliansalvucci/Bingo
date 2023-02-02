using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bingo.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialBolilleros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaYHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroDeBolilla = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialBolilleros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialBolilleros");
        }
    }
}
