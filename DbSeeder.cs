using ControlStock.Web.Data;
using ControlStock.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlStock.Web
{
    public static class DbSeeder
    {
        public static void SeedCategorias(ApplicationDbContext context)
        {
            if (context.Categorias.Any())
                return;

            var categorias = new List<Categoria>
            {
                new Categoria { Nombre = "Informática" },
                new Categoria { Nombre = "Oficina" },
                new Categoria { Nombre = "Gaming" },
                new Categoria { Nombre = "Accesorios" }
            };

            context.Categorias.AddRange(categorias);
            context.SaveChanges();
        }

        public static void SeedProductos(ApplicationDbContext context)
        {
            if (context.Productos.Any())
                return;

            var categorias = context.Categorias.AsNoTracking().ToList();

            var random = new Random();

            var productosBase = new[]
                    {
                "Laptop", "Mouse", "Teclado", "Monitor",
                "Impresora", "Auriculares", "Webcam", "Tablet"
            };

            var productos = new List<Producto>();

            for (int i = 1; i <= 100; i++)
            {
                var categoria = categorias[random.Next(categorias.Count)];

                productos.Add(new Producto
                {
                    Nombre = $"{productosBase[random.Next(productosBase.Length)]} {i}",
                    Precio = Math.Round((decimal)(random.Next(10, 2000) + random.NextDouble()), 2),
                    StockActual = random.Next(0, 100),
                    StockMinimo = random.Next(5, 20),
                    CategoriaId = categoria.Id
                });
            }

            context.Productos.AddRange(productos);
            context.SaveChanges();
        }
    }
}