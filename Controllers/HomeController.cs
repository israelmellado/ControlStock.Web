using ControlStock.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlStock.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos.ToListAsync();

            var model = new
            {
                TotalProductos = productos.Count,
                StockBajo = productos.Count(p => p.StockActual <= p.StockMinimo),
                TotalCategorias = await _context.Categorias.CountAsync()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
