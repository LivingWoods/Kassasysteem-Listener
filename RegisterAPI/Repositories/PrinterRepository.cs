using RegisterAPI.Models;

namespace RegisterAPI.Repositories
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly ApplicationDbContext _context;

        public PrinterRepository(ApplicationDbContext context)
        {            
            _context = context;
        }
        public async Task<Printer> GetPrinter(int id)
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();
                var printer = await _context.Printers.FindAsync(id);
                return printer;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreatePrinter(Printer printer)
        {
            await _context.Printers.AddAsync(printer);
            await _context.SaveChangesAsync();
        }
    }
}
