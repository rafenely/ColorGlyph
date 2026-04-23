using ColorGlyphs.Models;
using ColorGlyphs.Data;

namespace ColorGlyphs.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
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
                    Forma = "Cuadrada"
                },
                new GlyphModel
                {
                    Caracter = "Á",
                    Tipo = "Especial",
                    Colores = "Amarillo,Amarillo,Amarillo,Amarillo",
                    Forma = "Cuadrada,Rombo,Cuadrada,Cuadrada"
                },
                new GlyphModel
                {
                    Caracter = "E",
                    Tipo = "Vocal",
                    Colores = "Azul,Azul,Azul,Azul",
                    Forma = "Triangulo"
                },
                new GlyphModel
                {
                    Caracter = "I",
                    Tipo = "Vocal",
                    Colores = "Rojo,Rojo,Rojo,Rojo",
                    Forma = "Estrella"
                },
                new GlyphModel
                {
                    Caracter = "U",
                    Tipo = "Vocal",
                    Colores = "Verde,Verde,Verde,Verde",
                    Forma = "Rombo"
                },
                new GlyphModel
                {
                    Caracter = "O",
                    Tipo = "Vocal",
                    Colores = "Morado,Morado,Morado,Morado",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "B",
                    Tipo = "Consonante",
                    Colores = "Azul,Rojo,,Rojo",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "C",
                    Tipo = "Consonante",
                    Colores = "Azul,Verde,,Verde",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "D",
                    Tipo = "Consonante",
                    Colores = "Azul,Morado,,Morado",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "F",
                    Tipo = "Consonante",
                    Colores = "Rojo,,Morado,Morado",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "G",
                    Tipo = "Consonante",
                    Colores = "Rojo,,Amarillo,Amarillo",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "H",
                    Tipo = "Consonante",
                    Colores = "Amarillo,,Azul,Azul",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "J",
                    Tipo = "Consonante",
                    Colores = "Rojo,,Verde,Verde",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "K",
                    Tipo = "Consonante",
                    Colores = "Verde,,Rojo,Rojo",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "L",
                    Tipo = "Consonante",
                    Colores = "Amarillo,Amarillo,Morado,",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "M",
                    Tipo = "Consonante",
                    Colores = "Amarillo,Morado,Morado",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "N",
                    Tipo = "Consonante",
                    Colores = "Azul,Rojo,Rojo",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "Ñ",
                    Tipo = "Consonante",
                    Colores = "Azul,Rojo,Rojo,Rojo",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "P",
                    Tipo = "Consonante",
                    Colores = "Morado,Azul,Morado",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "Q",
                    Tipo = "Consonante",
                    Colores = ",Morado,Azul,Azul",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "R",
                    Tipo = "Consonante",
                    Colores = ",Amarillo,Rojo,Amarillo",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "S",
                    Tipo = "Consonante",
                    Colores = ",Rojo,Naranja,Naranja",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "T",
                    Tipo = "Consonante",
                    Colores = "Naranja,,Azul,Azul",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "V",
                    Tipo = "Consonante",
                    Colores = "Morado,Morado,Naranja",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "W",
                    Tipo = "Consonante",
                    Colores = ",Naranja,Amarillo,Azul",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "X",
                    Tipo = "Consonante",
                    Colores = "Morado,,Amarillo,Morado",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "Y",
                    Tipo = "Consonante",
                    Colores = "Naranja,Naranja,Amarillo,",
                    Forma = "Circulo"
                },
                new GlyphModel
                {
                    Caracter = "Z",
                    Tipo = "Consonante",
                    Colores = "Naranja,Naranja,,Verde,",
                    Forma = "Circulo"
                }
            };

            context.Glyphs.AddRange(initialGlyphs);
            context.SaveChanges();
        }
    }
}