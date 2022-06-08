using RegisterAPI.Models;

namespace RegisterAPI.Services
{
    public interface IPrinterStaffelService
    {
        Task<IEnumerable<PrinterStaffel>> GetPrinterStaffels();
        Task<PrinterStaffel> GetPrinterStaffel(int id);
        Task PutPrinterStaffel(int id, PrinterStaffel printerStaffel);
        Task PostPrinterStaffel(PrinterStaffel printerStaffel);
        Task DeletePrinterStaffel(int id);
    }
}
