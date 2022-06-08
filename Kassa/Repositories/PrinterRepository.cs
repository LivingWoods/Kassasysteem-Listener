using Kassa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kassa.Repositories
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly ApplicationDbContext _context;

        public PrinterRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Printer>> GetPrinters()
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();
                return await _context.Printers.Include(x => x.PrinterStaffels).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Printer> GetPrinter(int id)
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();
                return await _context.Printers.Include(x => x.PrinterStaffels).FirstOrDefaultAsync(x => x.PrinterId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Printer> GetPrinterByInterface(int interfaceId)
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();
                return await _context.Printers.Include(x => x.PrinterStaffels).FirstOrDefaultAsync(x => x.PrinterInterface == interfaceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Printer> UpdatePrinterTellerstandByInterface(int interfaceId)
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();
                Printer printer = await this.GetPrinterByInterface(interfaceId);
                
                if (printer == null)
                {
                    throw new NullReferenceException();
                }

                printer.PrinterHuidigeTeller = printer.PrinterHuidigeTeller + 1;
                _context.SaveChanges();

                return printer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
