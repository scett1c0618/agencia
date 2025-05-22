using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AgenciaDeViajes.Data;
using System.Linq;

namespace AgenciaDeViajes.Controllers
{
    [Authorize]
    public class CuentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Perfil()
        {
            var nombreUsuario = User.Identity.Name;
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
            return View(usuario);
        }
    }
}
