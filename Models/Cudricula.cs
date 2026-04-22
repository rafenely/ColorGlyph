using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LenguajeDeColores.Models;

public class Cuadricula
{
    [Key] // Identificador único
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public char Letra { get; set; }
    
    public string Tipo { get; set; } = "Consonante";
    
    // Guardaremos los colores como una cadena separada por comas (Ej: "Rojo,Azul")
    public string ColoresSerializados { get; set; } = string.Empty;

    public string Forma { get; set; } = "Circulo";
}