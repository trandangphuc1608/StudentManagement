using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectDB.Data;
using ConnectDB.Models;

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VariantsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Variant>>> GetVariants()
        {
            return await _context.Variants.Include(v => v.Product).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Variant>> GetVariant(int id)
        {
            var variant = await _context.Variants.Include(v => v.Product).FirstOrDefaultAsync(v => v.Id == id);
            if (variant == null) return NotFound();
            return variant;
        }

        [HttpPost]
        public async Task<ActionResult<Variant>> PostVariant(Variant variant)
        {
            _context.Variants.Add(variant);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVariant", new { id = variant.Id }, variant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariant(int id, Variant variant)
        {
            if (id != variant.Id) return BadRequest();

            _context.Entry(variant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Variants.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariant(int id)
        {
            var variant = await _context.Variants.FindAsync(id);
            if (variant == null) return NotFound();

            _context.Variants.Remove(variant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}