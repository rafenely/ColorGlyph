using Microsoft.EntityFrameworkCore;
using ColorGlyphs.Data;
using ColorGlyphs.Services;
using ColorGlyphs.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. SERVICIOS
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=LenguajeColores.db"));

builder.Services.AddControllers();
builder.Services.AddScoped<GlyphService>();

// Registro de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// 2. INICIALIZACIÓN DE DB (Mantenemos tu lógica igual)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    DbInitializer.Seed(context);
}

// 3. MIDDLEWARE (ORDEN CRÍTICO)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// ESTA LÍNEA es la que quita el error 404 de app.css y blazor.web.js
app.UseStaticFiles();

app.UseAntiforgery();

// 4. RUTAS
app.MapControllers(); // Para tu API (guardar letras)

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();