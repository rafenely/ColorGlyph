using System.ComponentModel.DataAnnotations;
namespace ColorGlyphs.Models;

public class FormModel
{
    [Key] // Identificador único
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public string Code { get; set; } = "";
}