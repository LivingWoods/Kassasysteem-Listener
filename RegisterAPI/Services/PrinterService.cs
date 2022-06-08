using RegisterAPI.Models;
using RegisterAPI.Repositories;

namespace RegisterAPI.Services
{
    public class PrinterService : IPrinterService
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterService(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }
        public Task DeletePrinter(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Printer> GetPrinter(int id)
        {
            return await _printerRepository.GetPrinter(id);
        }

        public Task<IEnumerable<Printer>> GetPrinters()
        {
            throw new NotImplementedException();
        }

        public async Task CreatePrinter(Printer printer)
        {
            await _printerRepository.CreatePrinter(printer);
        }

        public Task PutPrinter(int id, Printer printer)
        {
            throw new NotImplementedException();
        }
    }
}
