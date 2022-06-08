using Microsoft.EntityFrameworkCore;

namespace RegisterAPI.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Printer> Printers { get; set; }
        public DbSet<PrinterStaffel> PrinterStaffels { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Printer>().ToTable("Printers");
            modelBuilder.Entity<Printer>().HasKey(x => x.PrinterId);
            modelBuilder.Entity<Printer>().Property(x => x.PrinterInterface);
            modelBuilder.Entity<Printer>().Property(x => x.PrinterNaam);
            modelBuilder.Entity<Printer>().Property(x => x.PrinterHuidigeTeller);
            modelBuilder.Entity<Printer>().HasMany<PrinterStaffel>(x => x.PrinterStaffels).WithOne().HasForeignKey(x => x.Printer);

            modelBuilder.Entity<PrinterStaffel>().ToTable("PrinterStaffels");
            modelBuilder.Entity<PrinterStaffel>().HasKey(x => x.PrinterStaffelId);
            modelBuilder.Entity<PrinterStaffel>().Property(x => x.Prijs);
            modelBuilder.Entity<PrinterStaffel>().Property(x => x.Bovengrens);
            modelBuilder.Entity<PrinterStaffel>().Property(x => x.Ondergrens);
         


        }
    }

}
