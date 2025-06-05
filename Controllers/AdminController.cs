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

        public IActionResult Index()
        {
            return View();
        }

        // --- ADMIN DESTINOS PRINCIPAL ---
        public IActionResult AdminDestinos()
        {
            var regiones = _context.Regiones
                .Include(r => r.Destinos) // si tienes relación con Destinos
                .ToList();
            return View(regiones);
        }

        // ----------------- CRUD REGIONES -----------------

        public IActionResult CreateRegion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRegion(Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Regiones.Add(region);
                _context.SaveChanges();
                return RedirectToAction("AdminDestinos");
            }
            return View(region);
        }

        public IActionResult EditRegion(int id)
        {
            var region = _context.Regiones.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            return View(region);
        }

        [HttpPost]
        public IActionResult EditRegion(Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(region).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("AdminDestinos");
            }
            return View(region);
        }

        [HttpPost]
        public IActionResult DeleteRegion(int id)
        {
            var region = _context.Regiones.Find(id);
            if (region != null)
            {
                _context.Regiones.Remove(region);
                _context.SaveChanges();
            }
            return RedirectToAction("AdminDestinos");
        }

        // ----------------- CRUD DESTINOS (estructura base) -----------------

        public IActionResult CreateDestino()
        {
            ViewBag.Regiones = _context.Regiones.ToList(); // para seleccionar región
            return View();
        }

        [HttpPost]
        public IActionResult CreateDestino(Destino destino)
        {
            if (ModelState.IsValid)
            {
                _context.Destinos.Add(destino);
                _context.SaveChanges();
                return RedirectToAction("AdminDestinos");
            }
            ViewBag.Regiones = _context.Regiones.ToList();
            return View(destino);
        }

        public IActionResult EditDestino(int id)
        {
            var destino = _context.Destinos.Find(id);
            if (destino == null)
            {
                return NotFound();
            }
            ViewBag.Regiones = _context.Regiones.ToList();
            return View(destino);
        }

        [HttpPost]
        public IActionResult EditDestino(Destino destino)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(destino).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("AdminDestinos");
            }
            ViewBag.Regiones = _context.Regiones.ToList();
            return View(destino);
        }

        [HttpPost]
        public IActionResult DeleteDestino(int id)
        {
            var destino = _context.Destinos.Find(id);
            if (destino != null)
            {
                _context.Destinos.Remove(destino);
                _context.SaveChanges();
            }
            return RedirectToAction("AdminDestinos");
        }
    }
}
