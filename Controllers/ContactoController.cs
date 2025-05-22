using Microsoft.AspNetCore.Mvc;
using AgenciaDeViajes.Models;

namespace AgenciaDeViajes.Controllers
{
    public class ContactoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Aquí puedes: guardar en base de datos o enviar un correo (futuro)
            ViewBag.MensajeExito = "Tu mensaje fue enviado exitosamente. ¡Gracias por contactarnos!";

            ModelState.Clear(); // Limpia el formulario

            return View();
        }
    }
}
