using Microsoft.AspNetCore.Mvc;
using appAgencia.Models;

namespace appAgencia.Controllers
{
    public class ReservaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ReservaTour reserva)
        {
            if (!ModelState.IsValid)
            {
                return View(reserva);
            }
            return RedirectToAction("Confirmacion");
        }

        public IActionResult Confirmacion()
        {
            return View();
        }
    }
}
