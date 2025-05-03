using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appAgencia.Data;
using appAgencia.Models;

namespace appAgencia.Controllers
{
    public class FestividadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FestividadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Festividades
        public async Task<IActionResult> Index()
        {
            var festividades = await _context.Festividades
                .Include(f => f.Eventos)
                    .ThenInclude(e => e.Actividades)
                .ToListAsync();

            return View(festividades);
        }

        // Puedes agregar acciones Create, Edit, Details, Delete si lo necesitas
    }
}
