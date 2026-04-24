using System.ComponentModel.DataAnnotations;
namespace ColorGlyphs.Models;

public class GlyphColorModel
{
    [Key] // Identificador único
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public string Code { get; set; } = "#000000";
}