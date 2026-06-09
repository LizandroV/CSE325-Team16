using RestauranteApp.Data;
using RestauranteApp.Models;

namespace RestauranteApp.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(RestauranteDbContext context)
    {
        context.Database.EnsureCreated();

        // Seed admin user
        if (!context.Usuarios.Any())
        {
            context.Usuarios.Add(new Usuario
            {
                NombreUsuario = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Nombre = "Administrador",
                EsAdmin = true
            });
            await context.SaveChangesAsync();
        }

        // Seed menu items
        if (!context.MenuItems.Any())
        {
            var items = new List<MenuItem>
            {
                // MENU (Entradas)
                new MenuItem
                {
                    Nombre = "Tequeños",
                    Descripcion = "Crujientes palitos de masa rellenos de queso blanco, perfectos para compartir.",
                    Precio = 18.00m,
                    Categoria = "MENU",
                    ImagenUrl = "https://images.unsplash.com/photo-1604328698692-f76ea9498e76?w=600&q=80",
                    Disponible = true,
                    Orden = 1
                },
                new MenuItem
                {
                    Nombre = "Alitas BBQ",
                    Descripcion = "Alitas de pollo bañadas en salsa BBQ artesanal, acompañadas de dip de queso azul.",
                    Precio = 24.00m,
                    Categoria = "MENU",
                    ImagenUrl = "https://images.unsplash.com/photo-1567620832903-9fc6debc209f?w=600&q=80",
                    Disponible = true,
                    Orden = 2
                },
                new MenuItem
                {
                    Nombre = "Ceviche de Camarones",
                    Descripcion = "Camarones frescos marinados en limón, con ají amarillo, cebolla morada y cilantro.",
                    Precio = 32.00m,
                    Categoria = "MENU",
                    ImagenUrl = "https://images.unsplash.com/photo-1535399831218-d5bd36d1a6b3?w=600&q=80",
                    Disponible = true,
                    Orden = 3
                },
                new MenuItem
                {
                    Nombre = "Papas a la Huancaína",
                    Descripcion = "Papas sancochadas bañadas en crema de queso y ají amarillo, sobre hojas de lechuga.",
                    Precio = 16.00m,
                    Categoria = "MENU",
                    ImagenUrl = "https://images.unsplash.com/photo-1518013431117-eb1465fa5752?w=600&q=80",
                    Disponible = true,
                    Orden = 4
                },

                // NUESTROS PLATOS
                new MenuItem
                {
                    Nombre = "Ají de Gallina",
                    Descripcion = "Tiernas hebras de pollo en cremosa salsa de ají amarillo con nueces y queso, acompañado de arroz y papa.",
                    Precio = 38.00m,
                    Categoria = "NUESTROS_PLATOS",
                    ImagenUrl = "https://images.unsplash.com/photo-1574484284002-952d92456975?w=600&q=80",
                    Disponible = true,
                    Orden = 1
                },
                new MenuItem
                {
                    Nombre = "Pollo Frito",
                    Descripcion = "Jugoso pollo crujiente marinado en especias peruanas, con ensalada fresca y papas fritas.",
                    Precio = 35.00m,
                    Categoria = "NUESTROS_PLATOS",
                    ImagenUrl = "https://images.unsplash.com/photo-1626082927389-6cd097cdc6ec?w=600&q=80",
                    Disponible = true,
                    Orden = 2
                },
                new MenuItem
                {
                    Nombre = "Lomo Saltado",
                    Descripcion = "Clásico salteado de tiras de lomo fino con cebolla, tomate y ají, servido con arroz y papas fritas.",
                    Precio = 45.00m,
                    Categoria = "NUESTROS_PLATOS",
                    ImagenUrl = "https://images.unsplash.com/photo-1599974579688-8dbdd335c77f?w=600&q=80",
                    Disponible = true,
                    Orden = 3
                },
                new MenuItem
                {
                    Nombre = "Arroz con Leche",
                    Descripcion = "Cremoso postre de arroz con leche, canela y coco rallado, tradición peruana en cada cucharada.",
                    Precio = 14.00m,
                    Categoria = "NUESTROS_PLATOS",
                    ImagenUrl = "https://images.unsplash.com/photo-1568909344668-6f14a07b56a0?w=600&q=80",
                    Disponible = false,
                    Orden = 4
                },

                // ESPECIALES
                new MenuItem
                {
                    Nombre = "Pachamanca",
                    Descripcion = "Festín tradicional peruano: carnes, papas, humitas y habas cocidos bajo tierra con hierbas y piedras calientes. Mínimo 2 personas.",
                    Precio = 85.00m,
                    Categoria = "ESPECIALES",
                    ImagenUrl = "https://images.unsplash.com/photo-1504674900247-0877df9cc836?w=600&q=80",
                    Disponible = true,
                    Orden = 1
                },
                new MenuItem
                {
                    Nombre = "Ceviche Mixto",
                    Descripcion = "La estrella de la casa: corvina, camarones y pulpo en leche de tigre con ají limo, servido con choclo y camote.",
                    Precio = 65.00m,
                    Categoria = "ESPECIALES",
                    ImagenUrl = "https://images.unsplash.com/photo-1535399831218-d5bd36d1a6b3?w=600&q=80",
                    Disponible = true,
                    Orden = 2
                },

                // REFRESCOS
                new MenuItem
                {
                    Nombre = "Agua de Maracuyá",
                    Descripcion = "Refrescante bebida de maracuyá natural con un toque de azúcar y hierbabuena. Hecha al momento.",
                    Precio = 8.00m,
                    Categoria = "REFRESCOS",
                    ImagenUrl = "https://images.unsplash.com/photo-1621263764928-df1444c5e859?w=600&q=80",
                    Disponible = true,
                    Orden = 1
                },
                new MenuItem
                {
                    Nombre = "Chicha Morada",
                    Descripcion = "Bebida tradicional peruana de maíz morado con canela, clavo y frutas. Dulce y refrescante.",
                    Precio = 8.00m,
                    Categoria = "REFRESCOS",
                    ImagenUrl = "https://images.unsplash.com/photo-1556679343-c7306c1976bc?w=600&q=80",
                    Disponible = true,
                    Orden = 2
                },
                new MenuItem
                {
                    Nombre = "Limonada de Hierba Buena",
                    Descripcion = "Limonada fresca con hojas de hierbabuena, azúcar y hielo. El acompañante perfecto.",
                    Precio = 7.00m,
                    Categoria = "REFRESCOS",
                    ImagenUrl = "https://images.unsplash.com/photo-1621263764928-df1444c5e859?w=600&q=80",
                    Disponible = true,
                    Orden = 3
                },
                new MenuItem
                {
                    Nombre = "Inca Kola",
                    Descripcion = "La bebida dorada del Perú. Sabor único de hierba luisa que conquista corazones.",
                    Precio = 6.00m,
                    Categoria = "REFRESCOS",
                    ImagenUrl = "https://images.unsplash.com/photo-1527960471264-932f39eb5846?w=600&q=80",
                    Disponible = true,
                    Orden = 4
                },
            };

            context.MenuItems.AddRange(items);
            await context.SaveChangesAsync();
        }
    }
}
