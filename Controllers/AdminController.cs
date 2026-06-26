using ControlStock.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlStock.Web.ViewsModels;

namespace ControlStock.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos.ToListAsync();

            var model = new AdminDashboardViewModel
            {
                TotalProductos = productos.Count,
                StockBajo = productos.Count(p => p.StockActual <= p.StockMinimo),
                ValorInventario = productos.Sum(p => p.Precio * p.StockActual),
                TotalCategorias = await _context.Categorias.CountAsync()
            };

            return View(model);
        }

        public IActionResult Productos()
        {
            return RedirectToAction("Index", "Productos");
        }

        public IActionResult Categorias()
        {
            return RedirectToAction("Index", "Categorias");
        }
    }
}
