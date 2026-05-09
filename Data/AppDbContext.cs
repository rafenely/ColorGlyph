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

    public DbSet<DrawingMode> DrawingModes => Set<DrawingMode>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GlyphForm>()
            .HasKey(gf => new { gf.Id });

        modelBuilder.Entity<GlyphForm>()
            .HasOne(gf => gf.Glyph)
            .WithMany(g => g.GlyphForms)
            .HasForeignKey(gf => gf.GlyphId);

        modelBuilder.Entity<GlyphForm>()
            .HasOne(gf => gf.Form)
            .WithMany()
            .HasForeignKey(gf => gf.FormId);

        modelBuilder.Entity<GlyphModel>()
            .HasOne(g => g.DrawingMode)
            .WithMany(m => m.Glyphs)
            .HasForeignKey(g => g.DrawingModeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<DrawingMode>().HasData(
        new DrawingMode { Id = 1, Nombre = "Clásico" },
        new DrawingMode { Id = 2, Nombre = "Daltónico" }
        );
    }
}