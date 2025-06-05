using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AgenciaDeViajes.Data;
using AgenciaDeViajes.Models;

namespace AgenciaDeViajes.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string nombreUsuario, string contrasena)
        {
            // Verifica si el nombre ya está registrado
            var existe = _context.Usuarios.Any(u => u.NombreUsuario == nombreUsuario);

            if (existe)
            {
                ViewBag.Error = "Este nombre de usuario ya está registrado.";
                return View();
            }

            var nuevoUsuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                Rol = "Cliente" // o "Usuario"
            };

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();

            // Redirige al login
            return RedirectToAction("Index", "Login");
        }

    }
}
