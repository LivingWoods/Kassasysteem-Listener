using Microsoft.EntityFrameworkCore;

namespace Kassa_Backend.Models
{
    public class PrinterStaffelContext : DbContext
    {
        public PrinterStaffelContext(DbContextOptions<PrinterStaffelContext> options): base(options)
        {

        }

        public DbSet<PrinterStaffel> Staffels => Set<PrinterStaffel>();
    }
}
