using ColorGlyphs.Models;

public class DrawingMode
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty; // Ej: "Élfico", "Rúnico", "Clásico"

    // EF entiende esto automáticamente: Un modo tiene muchos glifos
    public List<GlyphModel> Glyphs { get; set; } = new();
}