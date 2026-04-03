using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectDB.Data;
using ConnectDB.Models;

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShipmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            return await _context.Shipments.Include(s => s.Order).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(int id)
        {
            var shipment = await _context.Shipments.Include(s => s.Order).FirstOrDefaultAsync(s => s.Id == id);
            if (shipment == null) return NotFound();
            return shipment;
        }

        [HttpPost]
        public async Task<ActionResult<Shipment>> PostShipment(Shipment shipment)
        {
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetShipment", new { id = shipment.Id }, shipment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipment(int id, Shipment shipment)
        {
            if (id != shipment.Id) return BadRequest();

            _context.Entry(shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Shipments.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null) return NotFound();

            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}