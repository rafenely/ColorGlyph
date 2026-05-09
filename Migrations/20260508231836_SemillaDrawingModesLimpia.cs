using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ColorGlyphs.Migrations
{
    /// <inheritdoc />
    public partial class SemillaDrawingModesLimpia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DrawingModes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 2, "Élfico" },
                    { 3, "Rúnico" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DrawingModes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DrawingModes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
