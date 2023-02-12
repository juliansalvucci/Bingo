using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bingo.Migrations
{
    public partial class historialCartones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialCartones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaYHora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carton1 = table.Column<int>(type: "int", nullable: false),
                    Carton2 = table.Column<int>(type: "int", nullable: false),
                    Carton3 = table.Column<int>(type: "int", nullable: false),
                    Carton4 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialCartones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialCartones");
        }
    }
}
