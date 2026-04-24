using ColorGlyphs.Models;
using ColorGlyphs.Data;

namespace ColorGlyphs.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            SeedForms(context);
            SeedColors(context);
            SeedGlyphs(context);
            SeedGlyphForm(context);
        }
        private static void SeedGlyphs(AppDbContext context)
        {
            // Solo actuamos si la base de datos está vacía
            if (context.Glyphs.Any()) return;

            var initialGlyphs = new List<GlyphModel>
            {
                new GlyphModel
                {
                    Caracter = "A",
                    Tipo = "Vocal",
                    Colores = "Amarillo,Amarillo,Amarillo,Amarillo",
                    //GlyphForms = "Cuadrada"
                },
                new GlyphModel
                {
                    Caracter = "Á",
                    Tipo = "Especial",
                    Colores = "Amarillo,Amarillo,Amarillo,Amarillo",
                    //GlyphForms = "Cuadrada,Rombo,Cuadrada,Cuadrada"
                },
                new GlyphModel
                {
                    Caracter = "E",
                    Tipo = "Vocal",
                    Colores = "Azul,Azul,Azul,Azul",
                    //GlyphForms = "Triangulo"
                },
                new GlyphModel
                {
                    Caracter = "I",
                    Tipo = "Vocal",
                    Colores = "Rojo,Rojo,Rojo,Rojo",
                    //GlyphForms = "Estrella"
                },
                new GlyphModel
                {
                    Caracter = "U",
                    Tipo = "Vocal",
                    Colores = "Verde,Verde,Verde,Verde",
                    //GlyphForms = "Rombo"
                },
                new GlyphModel
                {
                    Caracter = "O",
                    Tipo = "Vocal",
                    Colores = "Morado,Morado,Morado,Morado",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "B",
                    Tipo = "Consonante",
                    Colores = "Azul,Rojo,,Rojo",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "C",
                    Tipo = "Consonante",
                    Colores = "Azul,Verde,,Verde",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "D",
                    Tipo = "Consonante",
                    Colores = "Azul,Morado,,Morado",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "F",
                    Tipo = "Consonante",
                    Colores = "Rojo,,Morado,Morado",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "G",
                    Tipo = "Consonante",
                    Colores = "Rojo,,Amarillo,Amarillo",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "H",
                    Tipo = "Consonante",
                    Colores = "Amarillo,,Azul,Azul",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "J",
                    Tipo = "Consonante",
                    Colores = "Rojo,,Verde,Verde",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "K",
                    Tipo = "Consonante",
                    Colores = "Verde,,Rojo,Rojo",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "L",
                    Tipo = "Consonante",
                    Colores = "Amarillo,Amarillo,Morado,",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "M",
                    Tipo = "Consonante",
                    Colores = "Amarillo,Morado,Morado",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "N",
                    Tipo = "Consonante",
                    Colores = "Azul,Rojo,Rojo",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "Ñ",
                    Tipo = "Consonante",
                    Colores = "Azul,Rojo,Rojo,Rojo",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "P",
                    Tipo = "Consonante",
                    Colores = "Morado,Azul,Morado",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "Q",
                    Tipo = "Consonante",
                    Colores = ",Morado,Azul,Azul",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "R",
                    Tipo = "Consonante",
                    Colores = ",Amarillo,Rojo,Amarillo",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "S",
                    Tipo = "Consonante",
                    Colores = ",Rojo,Naranja,Naranja",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "T",
                    Tipo = "Consonante",
                    Colores = "Naranja,,Azul,Azul",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "V",
                    Tipo = "Consonante",
                    Colores = "Morado,Morado,Naranja",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "W",
                    Tipo = "Consonante",
                    Colores = ",Naranja,Amarillo,Azul",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "X",
                    Tipo = "Consonante",
                    Colores = "Morado,,Amarillo,Morado",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "Y",
                    Tipo = "Consonante",
                    Colores = "Naranja,Naranja,Amarillo,",
                    //GlyphForms = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "Z",
                    Tipo = "Consonante",
                    Colores = "Naranja,Naranja,,Verde,",
                    //GlyphForms = "Circulo"
                }
            };

            context.Glyphs.AddRange(initialGlyphs);
            context.SaveChanges();
        }
        private static void SeedForms(AppDbContext context)
        {
            if (context.Forms.Any()) return;

            var initialGlyphs = new List<FormModel>
            {
                new FormModel
                {
                    Description = "cuadrada",
                    Code = "border-radius: 2px;"
                },
                new FormModel
                {
                    Description = "circulo",
                    Code = "border-radius: 50%;"
                },
                new FormModel
                {
                    Description = "triangulo",
                    Code = "clip-path: polygon(50% 0%, 0% 100%, 100% 100%);"
                },
                new FormModel
                {
                    Description = "rombo",
                    Code = "clip-path: polygon(50% 0%, 100% 50%, 50% 100%, 0% 50%);"
                },
                new FormModel
                {
                    Description = "estrella",
                    Code = "clip-path: polygon(50% 0%, 61% 35%, 98% 35%, 68% 57%, 79% 91%, 50% 70%, 21% 91%, 32% 57%, 2% 35%, 39% 35%);"
                }
            };

            context.Forms.AddRange(initialGlyphs);
            context.SaveChanges();
        }
        private static void SeedColors(AppDbContext context)
        {
            if (context.Colours.Any()) return;

            var initialGlyphs = new List<GlyphColorModel>
            {
                new GlyphColorModel
                {
                    Description = "amarillo",
                    Code = "#FFD700"
                },
                 new GlyphColorModel
                {
                    Description = "azul",
                    Code = "#0000FF"
                },
                 new GlyphColorModel
                {
                    Description = "rojo",
                    Code = "#E32B00"
                },
                 new GlyphColorModel
                {
                    Description = "verde",
                    Code = "#008000"
                },
                 new GlyphColorModel
                {
                    Description = "naranja",
                    Code = "#FFA500"
                },
                 new GlyphColorModel
                {
                    Description = "morado",
                    Code = "#800080"
                }
            };

            context.Colours.AddRange(initialGlyphs);
            context.SaveChanges();
        }
        private static void SeedGlyphForm(AppDbContext context)
        {
            if (context.GlyphForms.Any()) return;

            // Buscamos los IDs que se acaban de crear
            var formaCirculo = context.Forms.First(f => f.Description == "circulo");
            var formaTriangulo = context.Forms.First(f => f.Description == "triangulo");

            var relaciones = new List<GlyphForm>
            {
                // Asignamos el Triángulo a la letra A
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "A").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "Á").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "Á").Id, FormId = formaTriangulo.Id, Order = 2 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "B").Id, FormId = formaTriangulo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "C").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "D").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "E").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "F").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "G").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "H").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "I").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "J").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "K").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "L").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "M").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "N").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "Ñ").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "O").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "P").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "Q").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "R").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "S").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "T").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "U").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "V").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "W").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "X").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "Y").Id, FormId = formaCirculo.Id, Order = 1 },
                new GlyphForm { GlyphId = context.Glyphs.First(g => g.Caracter == "Z").Id, FormId = formaCirculo.Id, Order = 1 },
                
                // Si quisieras agregar OTRA forma a la misma letra A, simplemente añades otra línea:
                // new GlyphForma { GlyphId = glyphA.Id, FormaId = otraForma.Id, Orden = 2 }
            };

            context.GlyphForms.AddRange(relaciones);
            context.SaveChanges();
        }
    }
}