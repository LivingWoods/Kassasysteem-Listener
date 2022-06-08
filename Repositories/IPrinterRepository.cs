using Kassa.Models;

namespace Kassa.Repositories
{
    public interface IPrinterRepository
    {
        // Read
        Task<IEnumerable<Printer>> GetPrinters();
        Task<Printer> GetPrinter(int id);
        Task<Printer> GetPrinterByInterface(int interfaceId);
        Task<Printer> UpdatePrinterTellerstandByInterface(int interfaceId);
    }
}
