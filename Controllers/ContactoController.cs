using Microsoft.AspNetCore.Mvc;

namespace appAgencia.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}