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

    public string Forma { get; set; } = "Circulo";
}