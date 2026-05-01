using ColorGlyphs.Data;
using ColorGlyphs.Models;
using Microsoft.EntityFrameworkCore;

namespace ColorGlyphs.Services;

public class ConfigService
{
    private readonly AppDbContext _context;

    public ConfigService(AppDbContext context)
    {
        _context = context;
    }
    public async Task CrearForma(FormModel g)
    {
        _context.Forms.Add(g);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarForma(FormModel g)
    {
        var local = _context.Forms.Local.FirstOrDefault(entry => entry.Id.Equals(g.Id));

        // Si existe, le decimos al contexto que deje de seguirlo
        if (local != null)
        {
            _context.Entry(local).State = EntityState.Detached;
        }
        _context.Entry(g).State = EntityState.Modified;

        _context.Forms.Update(g);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarForma(int id)
    {
        var g = await _context.Forms.FindAsync(id);
        if (g != null)
        {
            _context.Forms.Remove(g);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<FormModel>> ObtenerFormas() => await _context.Forms.AsNoTracking().ToListAsync();

    public async Task<List<GlyphForm>> ConvertirTextoAFormas(string texto)
    {
        var listaRelaciones = new List<GlyphForm>();
        if (string.IsNullOrWhiteSpace(texto)) return listaRelaciones;

        var nombres = texto.Split(',').Select(n => n.Trim().ToLower());
        var allForms = await _context.Forms.ToListAsync();
        var it = 0;
        foreach (var nombre in nombres)
        {
            var formaDb = allForms.FirstOrDefault(f => f.Description.ToLower() == nombre);
            if (formaDb != null)
            {
                listaRelaciones.Add(new GlyphForm { FormId = formaDb.Id, Order = it });
                it++;
            }
        }
        return listaRelaciones;
    }

    public async Task<List<GlyphColorModel>> ObtenerColores() => await _context.Colours.AsNoTracking().ToListAsync();

    public async Task CrearColor(GlyphColorModel g)
    {
        _context.Colours.Add(g);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarColor(GlyphColorModel g)
    {
        var local = _context.Colours.Local.FirstOrDefault(entry => entry.Id.Equals(g.Id));

        // Si existe, le decimos al contexto que deje de seguirlo
        if (local != null)
        {
            _context.Entry(local).State = EntityState.Detached;
        }
        _context.Entry(g).State = EntityState.Modified;

        _context.Colours.Update(g);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarColor(int id)
    {
        var g = await _context.Colours.FindAsync(id);
        if (g != null)
        {
            _context.Colours.Remove(g);
            await _context.SaveChangesAsync();
        }
    }

    public async Task CambiarTodasLasFormas(string nombreNuevaForma)
    {
        // 1. Buscamos la forma destino
        var formaDb = await _context.Forms
            .FirstOrDefaultAsync(f => f.Description.ToLower() == nombreNuevaForma.ToLower());

        if (formaDb == null) return;

        // 2. Traemos todos los glifos con sus relaciones actuales
        var todosLosGlyphs = await _context.Glyphs.Include(g => g.GlyphForms).ToListAsync();

        foreach (var glyph in todosLosGlyphs)
        {
            // Limpiamos las formas actuales
            _context.GlyphForms.RemoveRange(glyph.GlyphForms);

            // Asignamos la nueva forma
            glyph.GlyphForms.Add(new GlyphForm
            {
                GlyphId = glyph.Id,
                FormId = formaDb.Id,
                Order = 1
            });
        }

        await _context.SaveChangesAsync();
    }
}
