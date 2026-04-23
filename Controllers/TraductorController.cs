using Microsoft.AspNetCore.Mvc;
using ColorGlyphs.Data;
using ColorGlyphs.Services;

namespace ColorGlyphs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TraductorController : ControllerBase
{
    private readonly GlyphService _traductorService;
    private readonly AppDbContext _context;

    public TraductorController(GlyphService traductorService, AppDbContext context)
    {
        _traductorService = traductorService;
        _context = context;
    }

    [HttpGet("{texto}")]
    public IActionResult GetTraduccion(string texto)
    {
        var resultado = _traductorService.TraducirTexto(texto);
        return Ok(resultado);
    }

    [HttpPost("guardar")]
    public IActionResult GuardarLetra([FromBody] Models.GlyphModel nuevaLetra)
    {
        // Verificamos si la letra ya existe en la base de datos
        var existe = _context.Glyphs.Any(c => c.Caracter == nuevaLetra.Caracter);
        if (existe) return BadRequest("Esta letra ya está registrada.");

        _context.Glyphs.Add(nuevaLetra);
        _context.SaveChanges();

        return Ok($"Letra {nuevaLetra.Caracter} guardada correctamente.");
    }
}