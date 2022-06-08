using Kassa.Models;

namespace Kassa.Services
{
    public interface IPrinterService
    {
        Task<IEnumerable<Printer>> GetPrinters();
        Task<Printer> GetPrinter(int id);
        Task<Printer> UpdatePrinterTellerstandByInterface(int interfaceId);
    }
}
