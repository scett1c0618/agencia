using Microsoft.AspNetCore.Mvc;
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
            return View(new Usuario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(Usuario usuario, string confirmarContrasena)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Por favor, completa todos los campos requeridos correctamente.";
                return View(usuario);
            }

            if (usuario.Contrasena != confirmarContrasena)
            {
                ViewBag.Error = "Las contraseñas no coinciden.";
                return View(usuario);
            }

            bool yaExiste = _context.Usuarios.Any(u => u.NombreUsuario == usuario.NombreUsuario);
            if (yaExiste)
            {
                ViewBag.Error = "Este correo ya está registrado.";
                return View(usuario);
            }

            // Configura valores por defecto
            usuario.Rol = "Cliente";
            usuario.MetodoRegistro = "Manual";
            usuario.FechaRegistro = DateTime.UtcNow;

            if (usuario.FechaNacimiento.HasValue)
            {
                usuario.FechaNacimiento = DateTime.SpecifyKind(usuario.FechaNacimiento.Value, DateTimeKind.Utc);
            }


            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            TempData["MensajeExito"] = "Cuenta creada correctamente. Ya puedes iniciar sesión.";
            return RedirectToAction("Index", "Login");
        }
    }
}
