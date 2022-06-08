using RegisterAPI.Models;

namespace RegisterAPI.Repositories
{
    public interface IPrinterRepository
    {
        Task<Printer> GetPrinter(int id);
        Task CreatePrinter(Printer printer);
    }
}
