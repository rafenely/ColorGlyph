using System.Security.Cryptography;
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

    public async Task<List<GlyphModel>> ObtenerTodos() => await _context.Glyphs.Include(g => g.GlyphForms)
            .ThenInclude(gf => gf.Form).AsNoTracking().ToListAsync();

    public async Task Crear(GlyphModel g)
    {
        _context.Glyphs.Add(g);
        await _context.SaveChangesAsync();
    }

    public async Task Modificar(GlyphModel gM)
    {
        var glyphDb = await _context.Glyphs
        .Include(g => g.GlyphForms)
        .FirstOrDefaultAsync(g => g.Id == gM.Id);

        // Si existe, le decimos al contexto que deje de seguirlo
        if (glyphDb != null)
        {
            glyphDb.Caracter = gM.Caracter;
            glyphDb.Colores = gM.Colores;
            glyphDb.Tipo = gM.Tipo;

            _context.GlyphForms.RemoveRange(glyphDb.GlyphForms);
            await _context.SaveChangesAsync(); // Forzamos la limpieza en la DB primero

            glyphDb.GlyphForms = new List<GlyphForm>();
            foreach (var relacion in gM.GlyphForms)
            {
                glyphDb.GlyphForms.Add(new GlyphForm
                {
                    GlyphId = glyphDb.Id,
                    FormId = relacion.FormId,
                    Order = relacion.Order, // Si manejas orden
                });
            }
        }
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