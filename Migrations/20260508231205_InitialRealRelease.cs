using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColorGlyphs.Migrations
{
    /// <inheritdoc />
    public partial class InitialRealRelease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingModes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Glyphs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Caracter = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Colores = table.Column<string>(type: "TEXT", nullable: false),
                    DrawingModeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glyphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Glyphs_DrawingModes_DrawingModeId",
                        column: x => x.DrawingModeId,
                        principalTable: "DrawingModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlyphForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GlyphId = table.Column<int>(type: "INTEGER", nullable: false),
                    FormId = table.Column<int>(type: "INTEGER", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlyphForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlyphForms_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlyphForms_Glyphs_GlyphId",
                        column: x => x.GlyphId,
                        principalTable: "Glyphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DrawingModes",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Clásico" });

            migrationBuilder.CreateIndex(
                name: "IX_GlyphForms_FormId",
                table: "GlyphForms",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_GlyphForms_GlyphId",
                table: "GlyphForms",
                column: "GlyphId");

            migrationBuilder.CreateIndex(
                name: "IX_Glyphs_DrawingModeId",
                table: "Glyphs",
                column: "DrawingModeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "GlyphForms");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Glyphs");

            migrationBuilder.DropTable(
                name: "DrawingModes");
        }
    }
}
