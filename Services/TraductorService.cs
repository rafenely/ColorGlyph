using LenguajeDeColores.Data;
using LenguajeDeColores.Models;

namespace LenguajeDeColores.Services;

public class TraductorService
{
    private readonly AppDbContext _context;

    public TraductorService(AppDbContext context)
    {
        _context = context;
    }

    public List<Cuadricula> TraducirTexto(string texto)
    {
        var letrasEnTexto = texto.ToUpper().ToHashSet();
        
        // Buscamos solo las letras que necesitamos en la DB
        var letrasDb = _context.Cuadriculas
            .Where(c => letrasEnTexto.Contains(c.Letra))
            .ToDictionary(c => c.Letra);

        return texto.ToUpper()
            .Select(c => letrasDb.GetValueOrDefault(c, new Cuadricula { Letra = c, ColoresSerializados = "Gris" }))
            .ToList();
    }
}