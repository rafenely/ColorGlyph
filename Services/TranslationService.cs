using System.Threading.Tasks;
using ColorGlyphs.Data;
using ColorGlyphs.Models;
using Microsoft.EntityFrameworkCore;

namespace ColorGlyphs.Services;

public class TranslationService
{
    private readonly AppDbContext _context;
    private Dictionary<string, string> _cacheColores = new();

    public TranslationService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<GlyphModel>> TraducirTexto(string texto)
    {
        var letrasParaBuscar = texto.SelectMany(c => new[] { c.ToString(), c.ToString().ToUpper() })
        .Distinct()
        .ToList();

        // Buscamos solo las letras que necesitamos en la DB
        var letrasDb = await _context.Glyphs
            .Include(g => g.GlyphForms)
            .ThenInclude(gf => gf.Form)
            .Where(c => letrasParaBuscar.Contains(c.Caracter))
            .ToDictionaryAsync(c => c.Caracter);

        return texto.Select(c =>
            {
                string original = c.ToString();
                string mayuscula = original.ToUpper();

                if (original == "\n") return new GlyphModel { Caracter = "\n", Tipo = "Salto" };

                if (letrasDb.ContainsKey(original)) return letrasDb[original];

                if (letrasDb.ContainsKey(mayuscula)) return letrasDb[mayuscula];

                return new GlyphModel { Caracter = original, Colores = "Gris", Tipo = "Desconocido" };
            }).ToList();
    }
    public async Task<string> GetFormCode(string descripcion)
    {
        var forma = await _context.Forms
        .FirstOrDefaultAsync(f => f.Description.ToLower() == descripcion.ToLower().Trim());

        if (forma == null)
        {
            return new FormModel() { }.Code;
        }

        return forma.Code;
    }

    public async Task<string> GetColorCode(string colorName)
    {
        if (_cacheColores.TryGetValue(colorName, out var hex)) return hex;

        var color = await _context.Colours
        .FirstOrDefaultAsync(f => f.Description.ToLower() == colorName.ToLower().Trim());

        if (color == null)
        {
            return new GlyphColorModel() { }.Code;
        }

        return color.Code;
    }
}
