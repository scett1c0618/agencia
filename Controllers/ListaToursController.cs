using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgenciaDeViajes.Data;
using AgenciaDeViajes.Models;
using AgenciaDeViajes.Models.ViewModels;

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
            // Cargamos regiones con sus destinos desde la base de datos
            var regionesBD = _context.Regiones
                .Include(r => r.Destinos)
                .ToList();

            // Convertimos cada Region en RegionView
            var regionesView = regionesBD.Select(r => new RegionView
            {
                id_region = r.id_region,
                num_tours = r.num_tours,
                desc_region = r.desc_region,
                ImgReg_url = r.ImgReg_url,
                Destinos = r.Destinos.Select(d => new DestinoView
                {
                    id_destino = d.id_destino,
                    id_region = d.id_region,
                    nom_destino = d.nom_destino,
                    desc_destino = d.desc_destino,
                    precio_tour = d.precio_tour,
                    num_entradas = d.num_entradas,
                    time_tour = d.time_tour,
                    ImgDest_url = d.ImgDest_url
                }).ToList()
            }).ToList();

            return View(regionesView);
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
