using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LenguajeDeColores.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuadriculas",
                columns: table => new
                {
                    Letra = table.Column<char>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    ColoresSerializados = table.Column<string>(type: "TEXT", nullable: false),
                    Forma = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuadriculas", x => x.Letra);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuadriculas");
        }
    }
}
