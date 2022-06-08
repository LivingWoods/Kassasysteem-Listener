using RegisterAPI.Models;

namespace RegisterAPI.Services
{
    public interface IPrinterService
    {
        Task<IEnumerable<Printer>> GetPrinters();
        Task<Printer> GetPrinter(int id);
        Task CreatePrinter(Printer printer);
        Task DeletePrinter(int id);
    }
}
