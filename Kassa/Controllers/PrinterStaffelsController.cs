using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kassa.Models;

namespace Kassa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterStaffelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrinterStaffelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PrinterStaffels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrinterStaffel>>> GetPrinterStaffels()
        {
          if (_context.PrinterStaffels == null)
          {
              return NotFound();
          }
            return await _context.PrinterStaffels.ToListAsync();
        }

        // GET: api/PrinterStaffels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrinterStaffel>> GetPrinterStaffel(int id)
        {
          if (_context.PrinterStaffels == null)
          {
              return NotFound();
          }
            var printerStaffel = await _context.PrinterStaffels.FindAsync(id);

            if (printerStaffel == null)
            {
                return NotFound();
            }

            return printerStaffel;
        }

        // PUT: api/PrinterStaffels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrinterStaffel(int id, PrinterStaffel printerStaffel)
        {
            if (id != printerStaffel.PrinterStaffelId)
            {
                return BadRequest();
            }

            _context.Entry(printerStaffel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrinterStaffelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PrinterStaffels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrinterStaffel>> PostPrinterStaffel(PrinterStaffel printerStaffel)
        {
          if (_context.PrinterStaffels == null)
          {
              return Problem("Entity set 'ApplicationDbContext.PrinterStaffels'  is null.");
          }
            _context.PrinterStaffels.Add(printerStaffel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrinterStaffel", new { id = printerStaffel.PrinterStaffelId }, printerStaffel);
        }

        // DELETE: api/PrinterStaffels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrinterStaffel(int id)
        {
            if (_context.PrinterStaffels == null)
            {
                return NotFound();
            }
            var printerStaffel = await _context.PrinterStaffels.FindAsync(id);
            if (printerStaffel == null)
            {
                return NotFound();
            }

            _context.PrinterStaffels.Remove(printerStaffel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrinterStaffelExists(int id)
        {
            return (_context.PrinterStaffels?.Any(e => e.PrinterStaffelId == id)).GetValueOrDefault();
        }
    }
}
