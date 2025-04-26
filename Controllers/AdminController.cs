using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // ¡Importante para Include()!
using Microsoft.AspNetCore.Authorization;
using appAgencia.Data;
using appAgencia.Models;


[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        return View();
    }

    // REGIONES CRUD
    public ActionResult CreateRegion()
    {
        return View();
    }

    [HttpPost]
    public ActionResult CreateRegion(Region region)
    {
        if (ModelState.IsValid)
        {
            _context.Regiones.Add(region);
            _context.SaveChanges();
            return RedirectToAction("AdminDestinos");
        }
        return View(region);
    }

    public ActionResult EditRegion(int id)
    {
        var region = _context.Regiones.Find(id);
        if (region == null)
        {
            return NotFound();
        }
        return View(region);
    }

    [HttpPost]
    public ActionResult EditRegion(Region region)
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
    public ActionResult DeleteRegion(int id)
    {
        var region = _context.Regiones.Find(id);
        if (region != null)
        {
            _context.Regiones.Remove(region);
            _context.SaveChanges();
        }
        return RedirectToAction("AdminDestinos");
    }

    // DESTINOS CRUD (similar a regiones)
    // ...
}