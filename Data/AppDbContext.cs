using Microsoft.EntityFrameworkCore;
using LenguajeDeColores.Models;

namespace LenguajeDeColores.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Esta es tu tabla de letras
    public DbSet<Cuadricula> Cuadriculas => Set<Cuadricula>();
}