using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgenciaDeViajes.Data;
using AgenciaDeViajes.Models;

namespace AgenciaDeViajes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestividadesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FestividadesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FestividadesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festividad>>> GetFestividades()
        {
            var festividades = await _context.Festividades
                .Include(f => f.Eventos)
                    .ThenInclude(e => e.Actividades)
                .ToListAsync();
            return Ok(festividades);
        }

        // GET: api/FestividadesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Festividad>> GetFestividad(int id)
        {
            var festividad = await _context.Festividades
                .Include(f => f.Eventos)
                    .ThenInclude(e => e.Actividades)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (festividad == null)
                return NotFound();

            return Ok(festividad);
        }

        // POST: api/FestividadesApi
        [HttpPost]
        public async Task<ActionResult<Festividad>> CreateFestividad(Festividad festividad)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Festividades.Add(festividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFestividad), new { id = festividad.Id }, festividad);
        }

        // PUT: api/FestividadesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFestividad(int id, Festividad festividad)
        {
            if (id != festividad.Id)
                return BadRequest();

            _context.Entry(festividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Festividades.Any(f => f.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/FestividadesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFestividad(int id)
        {
            var festividad = await _context.Festividades.FindAsync(id);
            if (festividad == null)
                return NotFound();

            _context.Festividades.Remove(festividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
