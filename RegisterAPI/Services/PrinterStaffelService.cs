using RegisterAPI.Models;
using RegisterAPI.Repositories;

namespace RegisterAPI.Services
{
    public class PrinterStaffelService : IPrinterStaffelService
    {
        private readonly IPrinterStaffelRepository _printerStaffelRepository;

        public PrinterStaffelService(IPrinterStaffelRepository printerStaffelRepository)
        {
            _printerStaffelRepository = printerStaffelRepository;
        }
        public Task DeletePrinterStaffel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PrinterStaffel> GetPrinterStaffel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PrinterStaffel>> GetPrinterStaffels()
        {
            throw new NotImplementedException();
        }

        public Task PostPrinterStaffel(PrinterStaffel printerStaffel)
        {
            throw new NotImplementedException();
        }

        public Task PutPrinterStaffel(int id, PrinterStaffel printerStaffel)
        {
            throw new NotImplementedException();
        }
    }
}
