using Microsoft.EntityFrameworkCore;
using ColorGlyphs.Models;

namespace ColorGlyphs.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Esta es tu tabla de letras
    public DbSet<GlyphModel> Glyphs => Set<GlyphModel>();
}