using Microsoft.EntityFrameworkCore;

namespace Kassa_Backend.Models
{
    public class PrinterContext: DbContext
    {
        public PrinterContext(DbContextOptions<PrinterContext> options): base(options)
        {

        }

        public DbSet<Printer> Printers => Set<Printer>();
    }
}
