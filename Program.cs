using Microsoft.EntityFrameworkCore;
using LenguajeDeColores.Data;
using LenguajeDeColores.Services;
using LenguajeDeColores.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. SERVICIOS
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=LenguajeColores.db"));

builder.Services.AddControllers(); 
builder.Services.AddScoped<TraductorService>(); 

// Registro de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// 2. INICIALIZACIÓN DE DB (Mantenemos tu lógica igual)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    if (!context.Cuadriculas.Any())
    {
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'A', Tipo = "Vocal", ColoresSerializados = "Amarillo,Amarillo,Amarillo,Amarillo", Forma = "Cuadrada" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'E', Tipo = "Vocal", ColoresSerializados = "Azul,Azul,Azul,Azul", Forma = "Triangulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'I', Tipo = "Vocal", ColoresSerializados = "Rojo,Rojo,Rojo,Rojo", Forma = "Estrella" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'U', Tipo = "Vocal", ColoresSerializados = "Verde,Verde,Verde,Verde", Forma = "Rombo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'O', Tipo = "Vocal", ColoresSerializados = "Morado,Morado,Morado,Morado", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'B', Tipo = "Consonante", ColoresSerializados = "Azul,Rojo,,Rojo", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'C', Tipo = "Consonante", ColoresSerializados = "Azul,Verde,,Verde", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'D', Tipo = "Consonante", ColoresSerializados = "Azul,Morado,,Morado", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'F', Tipo = "Consonante", ColoresSerializados = "Rojo,,Morado,Morado", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'G', Tipo = "Consonante", ColoresSerializados = "Rojo,,Amarillo,Amarillo", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'H', Tipo = "Consonante", ColoresSerializados = "Amarillo,,Azul,Azul", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'J', Tipo = "Consonante", ColoresSerializados = "Rojo,,Verde,Verde", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'K', Tipo = "Consonante", ColoresSerializados = "Verde,,Rojo,Rojo", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'L', Tipo = "Consonante", ColoresSerializados = "Amarillo,Amarillo,Morado,", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'M', Tipo = "Consonante", ColoresSerializados = "Amarillo,Morado,Morado", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'N', Tipo = "Consonante", ColoresSerializados = "Azul,Rojo,Rojo", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'Ñ', Tipo = "Consonante", ColoresSerializados = "Azul,Rojo,Rojo,Rojo", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'P', Tipo = "Consonante", ColoresSerializados = "Morado,Azul,Morado", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'Q', Tipo = "Consonante", ColoresSerializados = ",Morado,Azul,Azul", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'R', Tipo = "Consonante", ColoresSerializados = ",Amarillo,Rojo,Amarillo", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'S', Tipo = "Consonante", ColoresSerializados = ",Rojo,Naranja,Naranja", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'T', Tipo = "Consonante", ColoresSerializados = "Naranja,,Azul,Azul", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'V', Tipo = "Consonante", ColoresSerializados = "Morado,Morado,Naranja", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'W', Tipo = "Consonante", ColoresSerializados = ",Naranja,Amarillo,Azul", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'X', Tipo = "Consonante", ColoresSerializados = "Morado,,Amarillo,Morado", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'Y', Tipo = "Consonante", ColoresSerializados = "Naranja,Naranja,Amarillo,", Forma = "Circulo" 
        });
        context.Cuadriculas.Add(new LenguajeDeColores.Models.Cuadricula { 
            Letra = 'Z', Tipo = "Consonante", ColoresSerializados = "Naranja,Naranja,,Verde,", Forma = "Circulo" 
        });
        context.SaveChanges();
    }
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