using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kassa_Backend.Models;

namespace Kassa_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterStaffelsController : ControllerBase
    {
        private readonly PrinterStaffelContext _context;

        public PrinterStaffelsController(PrinterStaffelContext context)
        {
            _context = context;
        }

        // GET: api/PrinterStaffels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrinterStaffel>>> GetStaffels()
        {
          if (_context.Staffels == null)
          {
              return NotFound();
          }
            return await _context.Staffels.ToListAsync();
        }

        // GET: api/PrinterStaffels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrinterStaffel>> GetPrinterStaffel(int id)
        {
          if (_context.Staffels == null)
          {
              return NotFound();
          }
            var printerStaffel = await _context.Staffels.FindAsync(id);

            if (printerStaffel == null)
            {
                return NotFound();
            }

            return printerStaffel;
        }

        // GET: api/PrinterStaffels/Printer/5
        /*[HttpGet("Printer/{printer}")]
        public async Task<ActionResult<PrinterStaffel>> GetPrinterStaffelByPrinter(int printer)
        {
            if (_context.Staffels == null)
            {
                return NotFound();
            }

            var printerStaffels = await _context.Staffels.Where(printer

            if (printerStaffels == null)
            {
                return NotFound();
            }

            return printerStaffels;
        }*/

        // PUT: api/PrinterStaffels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrinterStaffel(int id, PrinterStaffel printerStaffel)
        {
            if (id != printerStaffel.printerStaffelId)
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
          if (_context.Staffels == null)
          {
              return Problem("Entity set 'PrinterStaffelContext.Staffels'  is null.");
          }
            _context.Staffels.Add(printerStaffel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrinterStaffel", new { id = printerStaffel.printerStaffelId }, printerStaffel);
        }

        // DELETE: api/PrinterStaffels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrinterStaffel(int id)
        {
            if (_context.Staffels == null)
            {
                return NotFound();
            }
            var printerStaffel = await _context.Staffels.FindAsync(id);
            if (printerStaffel == null)
            {
                return NotFound();
            }

            _context.Staffels.Remove(printerStaffel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrinterStaffelExists(int id)
        {
            return (_context.Staffels?.Any(e => e.printerStaffelId == id)).GetValueOrDefault();
        }
    }
}
