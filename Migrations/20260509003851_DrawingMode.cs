using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColorGlyphs.Migrations
{
    /// <inheritdoc />
    public partial class DrawingMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DrawingModes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "DrawingModes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Daltónico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrawingModes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Élfico");

            migrationBuilder.InsertData(
                table: "DrawingModes",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 3, "Rúnico" });
        }
    }
}
