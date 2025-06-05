using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // ¡Importante para Include()!
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

        public IActionResult Destination()
        {
            // Obtener todas las regiones con sus destinos relacionados
            var regionesConDestinos = _context.Regiones
                .Include(r => r.Destinos) // Carga los destinos relacionados
                .ToList();

            return View(regionesConDestinos);
        }
        
    }
}