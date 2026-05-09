using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ColorGlyphs.Models;

public class GlyphModel
{
    [Key] // Identificador único
    public int Id { get; set; }
    public string Caracter { get; set; } = "";

    public string Tipo { get; set; } = "Consonante";

    public string Colores { get; set; } = string.Empty;
    public int DrawingModeId { get; set; }
    public DrawingMode DrawingMode { get; set; } = null!;

    public List<GlyphForm> GlyphForms { get; set; } = new();

    public string GetGlyphType()
    {
        string normal = "Consonante";
        string especial = "Especial";

        if (GlyphForms.Count() > 1)
            return especial;

        return normal;
    }
}