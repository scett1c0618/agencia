using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers // Reemplaza "TuProyecto" con el nombre de tu proyecto
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}