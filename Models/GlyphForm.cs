using System.ComponentModel.DataAnnotations;
namespace ColorGlyphs.Models;

public class GlyphForm
{
    [Key] // Identificador único
    public int Id { get; set; }
    public int GlyphId { get; set; }
    public GlyphModel Glyph { get; set; } = null!;

    public int FormId { get; set; }
    public FormModel Form { get; set; } = null!;

    public int Order { get; set; }
}