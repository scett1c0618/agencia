using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgenciaDeViajes.Data;
using AgenciaDeViajes.Models;

namespace AgenciaDeViajes.Controllers
{
    public class ListaToursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaToursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para listar todas las regiones con sus destinos
        public IActionResult Destination()
        {
            var regionesConDestinos = _context.Regiones
                .Include(r => r.Destinos)
                .ToList();

            return View(regionesConDestinos);
        }

        // Mostrar detalles de un destino con URL SEO
        [HttpGet]
        public async Task<IActionResult> Details(string nombreSeo)
        {
            if (string.IsNullOrEmpty(nombreSeo))
                return NotFound();

            // Busca el destino por el "slug" (nombreSeo)
            var destino = await _context.Destinos
                .FirstOrDefaultAsync(d =>
                    d.nom_destino.ToLower().Replace(" ", "-") == nombreSeo.ToLower()
                );

            if (destino == null)
                return NotFound();

            return View(destino);
        }
    }
}
