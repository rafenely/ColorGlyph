using ColorGlyphs.Data;
using ColorGlyphs.Models;
using Microsoft.EntityFrameworkCore;

namespace ColorGlyphs.Services;

public class GlyphService
{
    private readonly AppDbContext _context;

    public GlyphService(AppDbContext context)
    {
        _context = context;
    }

    public List<GlyphModel> TraducirTexto(string texto)
    {
        var letrasEnTexto = texto.SelectMany(c => new[] { c.ToString(), c.ToString().ToUpper() })
        .Distinct()
        .ToList();

        // Buscamos solo las letras que necesitamos en la DB
        var letrasDb = _context.Glyphs
            .Where(c => letrasEnTexto.Contains(c.Caracter))
            .ToDictionary(c => c.Caracter);


        return texto.Select(c =>
            {
                string original = c.ToString();
                string mayuscula = original.ToUpper();

                if (letrasDb.TryGetValue(original, out var encontrado))
                    return encontrado;

                if (letrasDb.TryGetValue(mayuscula, out var rescateMayus))
                    return rescateMayus;

                return new GlyphModel { Caracter = original, Colores = "Gris", Forma = "Circulo" };
            }).ToList();
    }
    public async Task<List<GlyphModel>> ObtenerTodos() => await _context.Glyphs.ToListAsync();

    public async Task Crear(GlyphModel g)
    {
        _context.Glyphs.Add(g);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(GlyphModel g)
    {
        _context.Glyphs.Update(g);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var g = await _context.Glyphs.FindAsync(id);
        if (g != null)
        {
            _context.Glyphs.Remove(g);
            await _context.SaveChangesAsync();
        }
    }
}