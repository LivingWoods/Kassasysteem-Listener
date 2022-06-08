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
    public class PrintersController : ControllerBase
    {
        private readonly PrinterContext _context;

        public PrintersController(PrinterContext context)
        {
            _context = context;
        }

        // GET: api/Printers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Printer>>> GetPrinters()
        {
          if (_context.Printers == null)
          {
              return NotFound();
          }
            return await _context.Printers.ToListAsync();
        }

        // GET: api/Printers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Printer>> GetPrinter(int id)
        {
          if (_context.Printers == null)
          {
              return NotFound();
          }
            var printer = await _context.Printers.FindAsync(id);

            if (printer == null)
            {
                return NotFound();
            }

            return printer;
        }

        // PUT: api/Printers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrinter(int id, Printer printer)
        {
            if (id != printer.printerId)
            {
                return BadRequest();
            }

            _context.Entry(printer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrinterExists(id))
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

        // POST: api/Printers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Printer>> PostPrinter(Printer printer)
        {
          if (_context.Printers == null)
          {
              return Problem("Entity set 'PrinterContext.Printers'  is null.");
          }
            _context.Printers.Add(printer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrinter", new { id = printer.printerId }, printer);
        }

        // DELETE: api/Printers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrinter(int id)
        {
            if (_context.Printers == null)
            {
                return NotFound();
            }
            var printer = await _context.Printers.FindAsync(id);
            if (printer == null)
            {
                return NotFound();
            }

            _context.Printers.Remove(printer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrinterExists(int id)
        {
            return (_context.Printers?.Any(e => e.printerId == id)).GetValueOrDefault();
        }
    }
}
