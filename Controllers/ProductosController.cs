
using ControlStock.Web.Data;
using ControlStock.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

//CONTROL AUTORIZACIONES
[Authorize(Roles = "Admin")]
public class ProductosController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PRODUCTOS + PAGINACIÓN + ORDENACIÓN
    public async Task<IActionResult> Index(int pagina = 1, string orden = "nombre", string buscar = "")
    {
        int tamanoPagina = 10;

        IQueryable<Producto> query = _context.Productos
                .Include(p => p.Categoria);

        // FILTRO DE BÚSQUEDA
        if (!string.IsNullOrEmpty(buscar))
        {
            query = query.Where(p => p.Nombre.Contains(buscar));
        }


        query = orden switch
        {
            "nombre_desc" => query.OrderByDescending(p => p.Nombre),

            "precio" => query.OrderBy(p => p.Precio),
            "precio_desc" => query.OrderByDescending(p => p.Precio),

            "stock" => query.OrderBy(p => p.StockActual),
            "stock_desc" => query.OrderByDescending(p => p.StockActual),

            "categoria" => query.OrderBy(p => p.Categoria!.Nombre),
            "categoria_desc" => query.OrderByDescending(p => p.Categoria!.Nombre),

            _ => query.OrderBy(p => p.Nombre)
        };
        var totalProductos = await query.CountAsync();

        var productos = await query
            .Skip((pagina - 1) * tamanoPagina)
            .Take(tamanoPagina)
            .ToListAsync();

        ViewBag.OrdenActual = orden;
        ViewBag.PaginaActual = pagina;
        ViewBag.TotalPaginas = (int)Math.Ceiling(totalProductos / (double)tamanoPagina);
        ViewBag.BuscarActual = buscar;


        return View(productos);
    }

    // GET: PRODUCTOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
                     .Include(p => p.Categoria)
                     .FirstOrDefaultAsync(m => m.Id == id);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // GET: PRODUCTOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,StockActual,StockMinimo,CategoriaId,Categoria")] Producto producto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }

    // GET: PRODUCTOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        var producto = await _context.Productos
                     .Include(p => p.Categoria)
                     .FirstOrDefaultAsync(p => p.Id == id);
        if (producto == null)
        {
            return NotFound();
        }
        ViewBag.Categorias = _context.Categorias.ToList();
        return View(producto);
    }

    // POST: PRODUCTOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Precio,StockActual,StockMinimo,CategoriaId,Categoria")] Producto producto)
    {
        if (id != producto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(producto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }

    // GET: PRODUCTOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
                    .Include(p => p.Categoria)
                    .FirstOrDefaultAsync(m => m.Id == id);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // POST: PRODUCTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductoExists(int? id)
    {
        return _context.Productos.Any(e => e.Id == id);
    }
}
