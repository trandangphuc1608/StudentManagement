using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectDB.Data;
using ConnectDB.Models;

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuditLogsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetAuditLogs()
        {
            return await _context.AuditLogs.OrderByDescending(a => a.Timestamp).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuditLog>> GetAuditLog(int id)
        {
            var auditLog = await _context.AuditLogs.FindAsync(id);
            if (auditLog == null) return NotFound();
            return auditLog;
        }

        [HttpPost]
        public async Task<ActionResult<AuditLog>> PostAuditLog(AuditLog auditLog)
        {
            _context.AuditLogs.Add(auditLog);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAuditLog", new { id = auditLog.Id }, auditLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditLog(int id)
        {
            var auditLog = await _context.AuditLogs.FindAsync(id);
            if (auditLog == null) return NotFound();

            _context.AuditLogs.Remove(auditLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}