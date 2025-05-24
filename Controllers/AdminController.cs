using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AgenciaDeViajes.Data;
using AgenciaDeViajes.Models;

namespace AgenciaDeViajes.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ============================
        // Página principal de administración
        // ============================
        public IActionResult Index()
        {
            return View();
        }

        // ============================
        // Panel de administración de Regiones y Destinos
        // ============================
        public IActionResult AdminDestinos()
        {
            var regiones = _context.Regiones
                .Include(r => r.Destinos)
                .ToList();

            return View(regiones);
        }

        // ========================================================
        // ================== CRUD REGIONES ========================
        // ========================================================

        // GET: Crear Región
        [HttpGet]
        public IActionResult CreateRegion()
        {
            return View();
        }

        // POST: Crear Región
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRegion(Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Regiones.Add(region);
                _context.SaveChanges();
                return RedirectToAction(nameof(AdminDestinos));
            }
            return View(region);
        }

        // GET: Editar Región
        [HttpGet]
        public IActionResult EditRegion(int id)
        {
            var region = _context.Regiones.Find(id);
            if (region == null) return NotFound();
            return View(region);
        }

        // POST: Editar Región
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRegion(Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Update(region);
                _context.SaveChanges();
                return RedirectToAction(nameof(AdminDestinos));
            }
            return View(region);
        }

        // POST: Eliminar Región
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRegion(int id)
        {
            var region = _context.Regiones.Find(id);
            if (region != null)
            {
                _context.Regiones.Remove(region);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(AdminDestinos));
        }

        // ========================================================
        // ================== CRUD DESTINOS ========================
        // ========================================================

        // GET: Crear Destino
        [HttpGet]
        public IActionResult CreateDestino()
        {
            ViewBag.Regiones = _context.Regiones.ToList(); // para el dropdown
            return View();
        }

        // POST: Crear Destino
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDestino(Destino destino)
        {
            if (ModelState.IsValid)
            {
                _context.Destinos.Add(destino);
                _context.SaveChanges();
                return RedirectToAction(nameof(AdminDestinos));
            }

            ViewBag.Regiones = _context.Regiones.ToList();
            return View(destino);
        }

        // GET: Editar Destino
        [HttpGet]
        public IActionResult EditDestino(int id)
        {
            var destino = _context.Destinos.Find(id);
            if (destino == null) return NotFound();

            ViewBag.Regiones = _context.Regiones.ToList();
            return View(destino);
        }

        // POST: Editar Destino
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDestino(Destino destino)
        {
            if (ModelState.IsValid)
            {
                _context.Update(destino);
                _context.SaveChanges();
                return RedirectToAction(nameof(AdminDestinos));
            }

            ViewBag.Regiones = _context.Regiones.ToList();
            return View(destino);
        }

        // POST: Eliminar Destino
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDestino(int id)
        {
            var destino = _context.Destinos.Find(id);
            if (destino != null)
            {
                _context.Destinos.Remove(destino);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(AdminDestinos));
        }
    }
}
