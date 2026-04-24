using Microsoft.EntityFrameworkCore;
using ColorGlyphs.Models;

namespace ColorGlyphs.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Esta es tu tabla de letras
    public DbSet<GlyphModel> Glyphs => Set<GlyphModel>();
    public DbSet<FormModel> Forms => Set<FormModel>();
    public DbSet<GlyphColorModel> Colours => Set<GlyphColorModel>();
    public DbSet<GlyphForm> GlyphForms => Set<GlyphForm>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuramos la llave primaria compuesta para la tabla intermedia
        modelBuilder.Entity<GlyphForm>()
            .HasKey(gf => new { gf.GlyphId, gf.FormId });

        modelBuilder.Entity<GlyphForm>()
            .HasOne(gf => gf.Glyph)
            .WithMany(g => g.GlyphForms)
            .HasForeignKey(gf => gf.GlyphId);

        modelBuilder.Entity<GlyphForm>()
            .HasOne(gf => gf.Form)
            .WithMany()
            .HasForeignKey(gf => gf.FormId);
    }
}