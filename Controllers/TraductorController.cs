using Microsoft.AspNetCore.Mvc;
using LenguajeDeColores.Data;
using LenguajeDeColores.Services;

namespace LenguajeDeColores.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TraductorController : ControllerBase
{
    private readonly TraductorService _traductorService;
     private readonly AppDbContext _context;

    public TraductorController(TraductorService traductorService, AppDbContext context)
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
    public IActionResult GuardarLetra([FromBody] LenguajeDeColores.Models.Cuadricula nuevaLetra)
    {
        // Verificamos si la letra ya existe en la base de datos
        var existe = _context.Cuadriculas.Any(c => c.Letra == nuevaLetra.Letra);
        if (existe) return BadRequest("Esta letra ya está registrada.");

        _context.Cuadriculas.Add(nuevaLetra);
        _context.SaveChanges();

        return Ok($"Letra {nuevaLetra.Letra} guardada correctamente.");
    }
}