using Microsoft.AspNetCore.Mvc;

namespace AgenciaDeViajes.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}