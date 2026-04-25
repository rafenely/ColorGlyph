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
            .Include(g => g.GlyphForms)
            .ThenInclude(gf => gf.Form)
            .Where(c => letrasEnTexto.Contains(c.Caracter))
            .ToDictionary(c => c.Caracter);

        return texto.Select(c =>
            {
                string original = c.ToString();
                string mayuscula = original.ToUpper();

                if (original == "\n") return new GlyphModel { Caracter = "\n", Tipo = "Salto" };

                if (letrasDb.TryGetValue(original, out var encontrado))
                {
                    return encontrado;
                }

                if (letrasDb.TryGetValue(mayuscula, out var rescateMayus))
                {
                    return rescateMayus;
                }

                return new GlyphModel { Caracter = original, Colores = "Gris", GlyphForms = new List<GlyphForm> { new GlyphForm { Form = new FormModel { Description = "Circulo" } } } };
            }).ToList();
    }
    public async Task<List<GlyphModel>> ObtenerTodos() => await _context.Glyphs.Include(g => g.GlyphForms)
            .ThenInclude(gf => gf.Form).AsNoTracking().ToListAsync();

    public async Task Crear(GlyphModel g)
    {
        _context.Glyphs.Add(g);
        await _context.SaveChangesAsync();
    }

    public string GetGlyphType(GlyphModel g)
    {
        string normal = "Consonante";
        string especial = "Especial";

        if (g.GlyphForms.Count() > 1)
            return especial;

        return normal;
    }

    public async Task Actualizar(GlyphModel gM)
    {
        //var glyphDb = _context.Glyphs.Local.FirstOrDefault(entry => entry.Id.Equals(gM.Id));
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
                    Order = relacion.Order // Si manejas orden
                });
            }

            //_context.Entry(glyphDb).State = EntityState.Detached;
        }
        //_context.Entry(gM).State = EntityState.Modified;

        //_context.Glyphs.Update(gM);
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

    //Formas
    public string GetFormCode(string descripcion)
    {
        /*var formaCode = _context.Forms
            .First(c => c.Description == descripcion.ToLower()).Code;


        return formaCode;*/

        var forma = _context.Forms
        .FirstOrDefault(f => f.Description.ToLower() == descripcion.ToLower().Trim());

        if (forma == null)
        {
            // Si no existe, devolvemos un estilo por defecto (ej: cuadrado)
            // Esto evita que el Traductor se rompa
            Console.WriteLine($"Advertencia: No se encontró la forma '{descripcion}'");
            return "border-radius: 0%;";
        }

        return forma.Code;
    }
    public async Task<List<FormModel>> ObtenerFormas() => await _context.Forms.AsNoTracking().ToListAsync();

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

    public async Task<List<GlyphForm>> ConvertirTextoAFormas(string texto)
    {
        var listaRelaciones = new List<GlyphForm>();
        if (string.IsNullOrWhiteSpace(texto)) return listaRelaciones;

        var nombres = texto.Split(',').Select(n => n.Trim().ToLower());

        foreach (var nombre in nombres)
        {
            var formaDb = await _context.Forms.FirstOrDefaultAsync(f => f.Description.ToLower() == nombre);
            if (formaDb != null)
            {
                listaRelaciones.Add(new GlyphForm { FormId = formaDb.Id });
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

    public string GetColorCode(string descripcion)
    {
        /*var formaCode = _context.Forms
            .First(c => c.Description == descripcion.ToLower()).Code;


        return formaCode;*/

        var color = _context.Colours
        .FirstOrDefault(f => f.Description.ToLower() == descripcion.ToLower().Trim());

        if (color == null)
        {
            // Si no existe, devolvemos un estilo por defecto (ej: cuadrado)
            // Esto evita que el Traductor se rompa
            Console.WriteLine($"Advertencia: No se encontró la forma '{descripcion}'");
            return "border-radius: 0%;";
        }

        return color.Code;
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